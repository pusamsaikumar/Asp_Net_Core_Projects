using JWTRoleAuthentication.CommonLayer.Models;
using JWTRoleAuthentication.Controllers;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace JWTRoleAuthentication.JWTDAL
{
    public class AuthRepo : IAuthRepo
    {
      
        private readonly IOptions<ConnectionStrings> _options;
        private readonly Helpers _helpers;
        private readonly IOptions<JWT> _jwt;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ValidationHelper _validationHelper;
        private readonly SqlHelpers _sqlHelpers;

        public AuthRepo(
            IOptions<ConnectionStrings> options,
            Helpers helpers,
            IOptions<JWT> jwt,
            IHttpContextAccessor httpContextAccessor,
            ValidationHelper validationHelper
            
            )
        {
            _options = options;
            _helpers = helpers;
            _jwt = jwt;
            _httpContextAccessor = httpContextAccessor;
            _validationHelper = validationHelper;
            _sqlHelpers = new SqlHelpers(_options.Value.AuthDBCon.ToString());
        }

        public async Task<RegisterResponse> GetUserDetails(string userName)
        {
            RegisterResponse response = null;
            response = new RegisterResponse();
           
            try
            {
                var storedProcName = "GetDetailsByUserName";
                var userNameParameter = new SqlParameter[]
                {
                    new SqlParameter("@UserName",userName)
                };
                var user = await _sqlHelpers.GetSingleRow(storedProcName, userNameParameter);
               
                if(user != null)
                {
                     response.Register = new Register();
                    response.Register = new Register
                    {
                        UserID = (Guid)(user["UserID"]),
                        FirstName = user["FirstName"].ToString(),
                        LastName = user["LastName"].ToString(),
                        UserName = user["UserName"].ToString(),
                        Email = user["Email"].ToString(),
                        DateOfBirth = Convert.ToDateTime(user["DateofBirth"]),

                        ZipCode = user["ZipCode"].ToString(),
                        MobileNumber = user["MobileNumber"].ToString(),
                        StoreID = Convert.ToInt32(user["StoreID"]),
                        Role = user["Role"].ToString()
                    };
                    response.StatusCode = 200;
                    response.StatusMessage = "User details has been found.";
                }

                response.StatusCode = 400;
                response.StatusMessage = "User details not found.";
            }
            catch(Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "Something went wrong.";
                
            }
            return response;
        }

        public async Task<RegisterResponse> GetTokensFromDB(string userName)
        {
            RegisterResponse response = null;
            response = new RegisterResponse();
           

            //string connectionString = _options.Value.AuthDBCon.ToString();
            try
            {
                var storedProcName = "GetDetailsByUserName";
                var userNameParameter = new SqlParameter[]
                {
                    new SqlParameter("@UserName",userName)
                };
                var user = await _sqlHelpers.GetSingleRow(storedProcName, userNameParameter);
               if(user != null)
                {
                    response.Register = new Register();
                    response.Register = new Register
                    {

                        Token = user["Token"].ToString(),
                        RefreshToken = user["RefreshToken"].ToString()


                    };

                    response.StatusCode = 200;
                    response.StatusMessage = "User tokens has been found.";
                }
                response.StatusCode = 400;
                response.StatusMessage = "User tokens not found.";

          


            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "Something went wrong.";

            }
           
            return response;
        }
        public async Task<RegisterResponse> SignUp(Register register)
        {
            RegisterResponse response = new RegisterResponse();

         
            try
            {

                var user = await GetUserDetails(register.UserName);
                if ( user !=null && user.Register != null &&  user.Register.UserName != null)
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "Email Id already existed.";
                    response.Register = null;
                  
                    return response;

                }
                string token = _helpers.GenerateJwtToken(register.UserName, register.Email, register.StoreID, register.DateOfBirth, register.Role);
                string refreshtoken = _helpers.GenerateRefreshToken();
                var storedProcName = "RegisterUser";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName", register.FirstName),
                    new SqlParameter("@LastName", register.LastName),
                    new SqlParameter("@UserName", register.UserName),
                    new SqlParameter("@Email", register.Email),
                    new SqlParameter("@Password", _helpers.EncryptedPassword(register.Password)),
                    new SqlParameter("@DateOfBirth", register.DateOfBirth),
                    new SqlParameter("@ZipCode", register.ZipCode),
                    new SqlParameter("@MobileNumber", register.MobileNumber),
                    new SqlParameter("@StoreID", register.StoreID),
                    new SqlParameter("@Token", token),
                    new SqlParameter("@RefreshToken", refreshtoken),
                    new SqlParameter("@Role", register.Role),
                };
               
                
                int rowAffected = await _sqlHelpers.InsertTable(storedProcName, parameters);
                if (rowAffected > 0)
                {
                    response.Register = new Register();
                    response.Register = register;
                    response.StatusCode = 200;
                    response.StatusMessage = "Registration has been successful.";
                    return response;
                }

                response.StatusCode = 400;
                response.StatusMessage = "Registration has been failed.";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "Something went wrong. Please try again.";
                response.Register = null;
            }

            return response;
        }

        public async Task<LoginResponse> Login(LoginModel model)
        {
            LoginResponse response = null;
            response= new LoginResponse();
        
           // string connectionString = _options.Value.AuthDBCon.ToString();
            try
            {
                var storedProcName = "Check_UserName_Password";
                int existedUserNamePassword = 0;
                //using (var cmd = _sqlHelpers.CreateStoredProcedureCommand(storedProcName))
                //{
                //    cmd.Parameters.AddWithValue("@UserName", model.UserName);
                //    cmd.Parameters.AddWithValue("@Password", _helpers.EncryptedPassword(model.Password));
                //    existedUserNamePassword = await _sqlHelpers.ExecuteScalarInt(cmd);
                //}
                var parameters = new SqlParameter[]
                {
                     new SqlParameter("@UserName", model.UserName),
                     new SqlParameter("@Password",_helpers.EncryptedPassword(model.Password))
                };
                 existedUserNamePassword = await _sqlHelpers.ExecuteIntScalar(storedProcName,parameters);
                if (existedUserNamePassword > 0)
                {
                    var getUser = await GetUserDetails(model.UserName); 
                    var user = await GetTokensFromDB(model.UserName);

                    response.TokenModel = new TokenModel();

                    if (_helpers.IsRefreshTokenExpired(user.Register.RefreshToken.ToString()))
                    {
                        response.TokenModel.RefreshToken = _helpers.GenerateRefreshToken();
                        response.TokenModel.Token = _helpers.GenerateJwtToken(getUser.Register.UserName, getUser.Register.Email, getUser.Register.StoreID, getUser.Register.DateOfBirth, getUser.Register.Role);


                        await UpdateTokenToDB(response.TokenModel, getUser.Register.UserID.ToString().ToUpper());

                     
                        _httpContextAccessor.HttpContext.Response.Headers.Add("AccessToken", response.TokenModel.Token);

             
                        response.StatusCode = 200;
                        response.StatusMessage = "User loggedin successfully.";

                        return response;
                    }

                    response.TokenModel.Token = user.Register.Token.ToString();
               
                    response.StatusCode = 200;
                    response.StatusMessage = "User loggedin successfully.";
                   
                    _httpContextAccessor.HttpContext.Response.Headers.Add("AccessToken", response.TokenModel.Token);
                    

                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "Invalid UserName or Password.";
                }

              

            }
            catch(Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "Something went wrong. Please try again.";
            }
            return response;
        }

        public async Task<TokenResponse> Refresh(TokenModel model)
        {
            TokenResponse tokenResponse = null;
            tokenResponse = new TokenResponse();


            try
            {
                var principal = _helpers.GetPrincipalFromExpiredToken(model.Token);
                string userName = principal.Identity.Name;
                var user = await GetUserDetails(userName);

                if (principal == null || user.Register.UserName != null )
                {
                    tokenResponse.StatusCode = 400;
                    tokenResponse.StatusMessage = "Invalid access token or refresh token";
                    tokenResponse.TokenModel = null;


                }
                var newAccessToken = _helpers.GenerateJwtToken(user.Register.UserName, user.Register.Email, user.Register.StoreID, user.Register.DateOfBirth, user.Register.Role);
                var newRefreshToken = _helpers.GenerateRefreshToken();
                tokenResponse.TokenModel = new TokenModel();
                tokenResponse.TokenModel.Token = newAccessToken;
                tokenResponse.TokenModel.RefreshToken = newRefreshToken;


                string userID = user.Register.UserID.ToString().ToUpper();
                var updatetoken = await UpdateTokenToDB(tokenResponse.TokenModel, userID);


                //_httpContextAccessor.HttpContext.Response.Headers.Add("Authorization", $"Bearer {newAccessToken}");
                _httpContextAccessor.HttpContext.Response.Headers.Add("AccessToken", newAccessToken);
                _httpContextAccessor.HttpContext.Response.Headers.Add("RefreshToken", newRefreshToken);

                tokenResponse.StatusCode = 200;
                tokenResponse.StatusMessage = "Token refreshed successfully....";



              

            }
            catch (Exception ex)
            {
                tokenResponse.StatusCode = 500;
                tokenResponse.StatusMessage = "An error occurred while refreshing token";




            }



            return tokenResponse;
        }


        public async Task<TokenResponse> GetTokenRefreshTokenById(string userId)
        {
          TokenResponse tokenResponse = new TokenResponse();
            tokenResponse.TokenModel = new TokenModel();
           // string connectionString = _options.Value.AuthDBCon.ToString();
            try
            {
                var storedProcName = "GetTokens";
                var userIdParameter = new SqlParameter("@UserID", userId);
                var user = await _sqlHelpers.GetSingleRow(storedProcName, userIdParameter); 
                 if(user != null)
                {
                    tokenResponse.TokenModel = new TokenModel
                              {
                                 Token = user["Token"].ToString(),
                                 RefreshToken = user["RefreshToken"].ToString(),
                               };
                    tokenResponse.StatusCode = 200;
                    tokenResponse.StatusMessage = "Token details has been found.";
                }              
            }
            catch (Exception ex)
            {
               tokenResponse.StatusCode = 500;
                tokenResponse.StatusMessage = "Something went wrong.";

            }
            return tokenResponse;
        }

  

        public async Task<TokenResponse> UpdateTokenToDB(TokenModel model, string userId)
        {
            TokenResponse tokenResponse = new TokenResponse();
            tokenResponse.TokenModel = new TokenModel();
            var storedProcName = "UpdateTokens";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@Token",model.Token),
                new SqlParameter("@RefreshToken", model.RefreshToken)
            };
            int rowsAffected = await _sqlHelpers.UpdateTable(storedProcName, parameters);
            try
            {
                if(rowsAffected > 0)
                {
                    tokenResponse.StatusCode = 200;
                    tokenResponse.StatusMessage = "Updated token successfully.";
                }
                else
                {
                     tokenResponse.StatusCode = 400; 
                     tokenResponse.StatusMessage = "Tokens updation has been failed.";
                }
            }
            catch(Exception ex)
            {
                tokenResponse.StatusCode = 500;
                tokenResponse.StatusMessage = "Something went wrong.";
            }
          return tokenResponse;
        }
        public async Task<ResponseDataTypes> InsertSampleData(SampleDataTypes model)
        {
            ResponseDataTypes responseDataTypes = new ResponseDataTypes();
            try
            {
                
             
                // validate model before inserting a record:
                //_validationHelper.ValidateModel(model);



                // string to byte[]

                //byte[] profile = System.Text.Encoding.UTF8.GetBytes(model.ProfileName);

                // _validationHelper.ValidateModelParameters(model);
               
               
                var storedProcName = "InsertDataTypes";
                var parameters = new SqlParameter[]
                {
                  
                //new SqlParameter("@UserName",string.IsNullOrEmpty(model.UserName) ? (object)DBNull.Value : model.UserName),

                //new SqlParameter("@UserName",string.IsNullOrEmpty(model.UserName) ? string.Empty : model.UserName),
                new SqlParameter("@UserName",string.IsNullOrEmpty(model.UserName) ? string.Empty : model.UserName),
                
                
                 //new SqlParameter("@Age",model.Age == null ? 0 : model.Age),

                 new SqlParameter("@Age",string.IsNullOrEmpty(model?.Age.ToString()) ? 0 : int.Parse(model?.Age.ToString())),
                //new SqlParameter("@Age",model.Age == null ? (object)DBNull.Value : model.Age),
                //new SqlParameter("@Age",model.Age == null ? 0 : (model.Age is string) ? int.Parse(model.Age.ToString()) :  model.Age),


               


                  //new SqlParameter("@IsActive",model.IsActive == null ? false : model.IsActive),
                 // new SqlParameter("@IsActive",model.IsActive == null ?(object)DBNull.Value : model.IsActive),
                 new SqlParameter("@IsActive",string.IsNullOrEmpty(model.IsActive.ToString() ) ? false : model.IsActive),
                  

                // new SqlParameter("@DateOfBirth",model.DateOfBirth == null ? (object)DBNull.Value : model.DateOfBirth),

                 // new SqlParameter("@DateOfBirth",model.DateOfBirth == null? DateTime.Now : model.DateOfBirth),
                
                 //new SqlParameter("@DateOfBirth",string.IsNullOrEmpty(model.DateOfBirth.ToString()) ? (object)DBNull.Value : (object)DateTime.Parse(model.DateOfBirth.ToString())),
                //new SqlParameter("@DateOfBirth",string.IsNullOrEmpty(model.DateOfBirth.ToString()) ? DateTime.Now : (object)DateTime.Parse(model?.DateOfBirth?.ToString())),
                new SqlParameter("@DateOfBirth",string.IsNullOrEmpty(model.DateOfBirth.ToString()) ? new DateTime(1900,1,1) : model.DateOfBirth),
                 
                 
                    
                 //new SqlParameter("@Doublevalue",model.Doublevalue == null ? 0.0 : model.Doublevalue),
                  //new SqlParameter("@Doublevalue",model.Doublevalue == null ? (object)DBNull.Value : model.Doublevalue),
                  new SqlParameter("@Doublevalue",string.IsNullOrEmpty(model.Doublevalue.ToString()) ? 0.0 : model.Doublevalue),



               // new SqlParameter("@Profile",model.Profile == null ? new byte[0] : model.Profile),
                 new SqlParameter("@Profile",string.IsNullOrEmpty(model?.Profile?.ToString()) ? new byte[0] : model.Profile),




                 //new SqlParameter("@UserID",model.UserID == null ? Guid.NewGuid() : model.UserID),
                 //new SqlParameter("@UserID",model.UserID == null ? (object)DBNull.Value : model.UserID),

                 new SqlParameter("@UserID",string.IsNullOrEmpty(model?.UserID.ToString()) ? Guid.NewGuid() : model.UserID),



                 //new SqlParameter("@TimeSpanValue",model.TimeSpanValue == null ? TimeSpan.Zero : model.TimeSpanValue),
                 //new SqlParameter("@TimeSpanValue",model?.TimeSpanValue == null ? (object)DBNull.Value : model.TimeSpanValue),
                 new SqlParameter("@TimeSpanValue",string.IsNullOrEmpty(model?.TimeSpanValue.ToString() ) ? TimeSpan.Zero : model.TimeSpanValue),


                // new SqlParameter("@Salary",model?.Salary == null ? 0.0 : model.Salary),
                // new SqlParameter("@Salary",model?.Salary == null ? (object)DBNull.Value : model.Salary),
                new SqlParameter("@Salary",string.IsNullOrEmpty(model?.Salary.ToString()) ? 0.0 : model.Salary),


                new SqlParameter("@JoinDate",model?.JoinDate == null ?  new DateTime(1900,1,1).ToString("yyyy-MM-dd") : model.JoinDate),
                 
                 //new SqlParameter("@JoinDate",model.JoinDate == null ? DBNull.Value : model.JoinDate),
                // new SqlParameter("@JoinDate",string.IsNullOrEmpty(model?.JoinDate.ToString()) ? (object)DBNull.Value : model.JoinDate),




                  //new SqlParameter("@Price",model.Price == null ? 0.00 : model.Price)
                //  new SqlParameter("@Price",model?.Price == null ? (object)DBNull.Value : model.Price)
                 new SqlParameter("@Price",string.IsNullOrEmpty(model?.Price.ToString()) ? 0.00 : model.Price)




                };

                int rowsAffected = await _sqlHelpers.InsertTable(storedProcName, parameters);
                if(rowsAffected > 0)
                {
                    responseDataTypes.StatusCode = 200;
                    responseDataTypes.StatusMessage = "Record inserted successfully.";
                    responseDataTypes.SampleDataTypes = model;
                }
                else
                {
                    responseDataTypes.StatusCode = 400;
                    responseDataTypes.StatusMessage = "failed.";
                    
                }
            }
             catch(SqlException ex)
            {
                responseDataTypes.StatusCode = 500;
                responseDataTypes.StatusMessage = ex.Message.ToString();
            }
            
            catch(Exception ex)
            {
                responseDataTypes.StatusCode = 500;
                responseDataTypes.StatusMessage =ex.Message.ToString();
            }
            return responseDataTypes;
        }

        public byte[] ConvertToBaseString(string data)
        {
            return Convert.FromBase64String(data);  
        }

    }
}
