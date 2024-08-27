using JWTRoleBaseAuthentication.CommonLayer.Models;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace JWTRoleBaseAuthentication.DataAccessLayer
{
    public class AuthRepo : IAuthRepo
    {
        private readonly IOptions<ConnectionStrings> _options;
        private readonly Helpers _helpers;
        private readonly IOptions<JWT> _jwt;

        public AuthRepo(
            IOptions<ConnectionStrings> options,
            Helpers helpers,
            IOptions<JWT> jwt

            )
        {
            _options = options;
            _helpers = helpers;
            _jwt = jwt;
        }

        public async Task<RegisterResponse> GetUserDetails(string userName)
        {
            RegisterResponse response = null;
            response = new RegisterResponse();
            response.Register = new Register();

            string connectionString = _options.Value.AuthDBCon.ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetDetailsByUserName", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Register = new Register
                                {
                                    UserID = reader.GetGuid(reader.GetOrdinal("UserID")),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    UserName = reader["UserName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    //  DateOfBirth = Convert.ToDateTime(reader["DateofBirth"]),
                                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                    ZipCode = reader["ZipCode"].ToString(),
                                    MobileNumber = reader["MobileNumber"].ToString(),
                                    StoreID = Convert.ToInt32(reader["StoreID"]),
                                    Role = reader["Role"].ToString()


                                };
                            }
                        }
                    }

                }
                response.StatusCode = 200;
                response.StatusMessage = "User details has been found.";
            }
            catch (Exception ex)
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
            response.Register = new Register();

            string connectionString = _options.Value.AuthDBCon.ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetDetailsByUserName", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Register = new Register
                                {
                                    //UserID = reader.GetGuid(reader.GetOrdinal("UserID")),
                                    //FirstName = reader["FirstName"].ToString(),
                                    //LastName = reader["LastName"].ToString(),
                                    //UserName = reader["UserName"].ToString(),
                                    //Email = reader["Email"].ToString(),
                                    ////  DateOfBirth = Convert.ToDateTime(reader["DateofBirth"]),
                                    //DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                    //ZipCode = reader["ZipCode"].ToString(),
                                    //MobileNumber = reader["MobileNumber"].ToString(),
                                    //StoreID = Convert.ToInt32(reader["StoreID"]),
                                    //Role = reader["Role"].ToString(),
                                    Token = reader["Token"].ToString(),
                                    RefreshToken = reader["RefreshToken"].ToString()




                                };
                            }
                        }
                    }

                }

                response.StatusCode = 200;
                response.StatusMessage = "User details has been found.";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "Something went wrong.";

            }

            return response;
        }
        public async Task<LoginResponse> Login(LoginModel model)
        {
            LoginResponse response = null;
            response = new LoginResponse();
            //  response.TokenModel = new TokenModel();
            string connectionString = _options.Value.AuthDBCon.ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand checkLogin = new SqlCommand("Check_UserName_Password", conn);
                    checkLogin.CommandType = System.Data.CommandType.StoredProcedure;
                    checkLogin.Parameters.AddWithValue("@UserName", model.UserName);
                    checkLogin.Parameters.AddWithValue("@Password", _helpers.EncryptedPassword(model.Password));
                    int variable = (int)checkLogin.ExecuteScalar();
                    await conn.CloseAsync();
                    if (variable > 0)
                    {
                        //var user = await GetUserDetails(model.UserName);
                        var user = await GetTokensFromDB(model.UserName);
                        response.TokenModel = new TokenModel
                        {
                            Token = user.Register.Token.ToString(),
                            RefreshToken = user.Register.RefreshToken.ToString(),
                            RefreshTokenExpiresIn = DateTime.UtcNow.AddMinutes(_jwt.Value.RefreshTokenValidityInMinutes)
                        };
                        response.StatusCode = 200;
                        response.StatusMessage = "User loggedin successfully.";
                    }
                    else
                    {
                        response.StatusCode = 400;
                        response.StatusMessage = "Invalid UserName or Password.";
                    }
                }

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
            response.Register = register;
            string connectionString = _options.Value.AuthDBCon.ToString();
            try
            {
                string token = _helpers.GenerateJwtToken(register.UserName, register.Email, register.StoreID, register.DateOfBirth, register.Role);
                string refreshtoken = _helpers.GenerateRefreshToken();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand checkEmail = new SqlCommand("Get_UserName", conn);

                    checkEmail.CommandType = System.Data.CommandType.StoredProcedure;
                    checkEmail.Parameters.AddWithValue("@UserName", register.UserName);
                    string userName = (string)checkEmail.ExecuteScalar();
                    if (userName == register.UserName)
                    {
                        response.StatusCode = 400;
                        response.StatusMessage = "Email Id already existed.";
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("User_Register", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@FirstName", register.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", register.LastName);
                        cmd.Parameters.AddWithValue("@UserName", register.UserName);
                        cmd.Parameters.AddWithValue("@Email", register.Email);
                        cmd.Parameters.AddWithValue("@Password", _helpers.EncryptedPassword(register.Password));
                        cmd.Parameters.AddWithValue("@DateOfBirth", register.DateOfBirth);
                        cmd.Parameters.AddWithValue("@ZipCode", register.ZipCode);
                        cmd.Parameters.AddWithValue("@MobileNumber", register.MobileNumber);
                        cmd.Parameters.AddWithValue("@StoreID", register.StoreID);
                        //cmd.Parameters.AddWithValue("@Token", register.Token);
                        //cmd.Parameters.AddWithValue("@RefreshToken", register.RefreshToken);
                        cmd.Parameters.AddWithValue("@Token", token);
                        cmd.Parameters.AddWithValue("@RefreshToken", refreshtoken);
                        cmd.Parameters.AddWithValue("@Role", register.Role);
                        await cmd.ExecuteNonQueryAsync();

                    }






                    await conn.CloseAsync();
                }
                response.StatusCode = 201;
                response.StatusMessage = "Registration has been successful.";

            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "Registration has been failed.";
            }

            return response;
        }
    }
}

