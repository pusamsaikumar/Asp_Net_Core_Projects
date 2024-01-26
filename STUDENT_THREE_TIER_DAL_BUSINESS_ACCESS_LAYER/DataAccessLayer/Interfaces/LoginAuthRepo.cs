using CommonLayer.Models;
using DataAccessLayer.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Twilio.Jwt.AccessToken;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Interfaces
{
    public class LoginAuthRepo: ILoginAuthRepo
    {
        private readonly IOptions<ConnectionStrings> _config;
        private readonly IOptions<AppSettings> _appsettings;
        private readonly IConfiguration _configuration;
        private readonly IOptions<JWT> _jwt;
        private readonly IHttpContextAccessor _httpContextAccessor;
       // private readonly UserManager<ApplicationUser> _userManager;

        public LoginAuthRepo(
            IOptions<ConnectionStrings> config,
            IOptions<AppSettings> appsettings,
            IConfiguration configuration,
            IOptions<JWT> jwt,
            IHttpContextAccessor httpContextAccessor
             // UserManager<ApplicationUser> userManager
            )
        {
            _config = config;
            _appsettings = appsettings;
            _configuration = configuration;
            _jwt = jwt;
            _httpContextAccessor = httpContextAccessor;
       //   _userManager = userManager;
        }

      //  public async Task<RegisterModel> GetByEmail(string email)

        public Response GetByEmail(string email)
        {
            

            string connection = _config.Value.SNCon.ToString();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                Response response = new Response();
                conn.Open();


                // check email:
                SqlCommand checkEmail = new SqlCommand("check_email_register", conn);

                checkEmail.CommandType = System.Data.CommandType.StoredProcedure;
                checkEmail.Parameters.AddWithValue("@Email", email);
                string emailid = (string)checkEmail.ExecuteScalar();
                if( emailid != email )
                {
                    response.StatusCode = 404;
                    response.StatusMessage = "Invalid email id";
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("usp_getby_email", conn);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Email", email);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    var register = new RegisterModel();
                    conn.Close();
                    if (dataTable.Rows.Count > 0)
                    {
                        register.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                        register.UserName = Convert.ToString(dataTable.Rows[0]["UserName"]);

                        register.Email = Convert.ToString(dataTable.Rows[0]["Email"]);
                        register.Password = Convert.ToString(dataTable.Rows[0]["Password"]);
                        register.Role = Convert.ToString(dataTable.Rows[0]["Role"]);
                        
                       

                        response.StatusMessage = "Ok";
                        response.StatusCode = 200;
                        response.Register = register;


                    }
                    else
                    {
                        return null;
                    }
                }
                

                // return  await Task.FromResult(register);
                // return register;

                return response;
            }
        }

        public Response Login(LoginModel login)
        {
            Response response = new Response();
            string connection = _config.Value.SNCon.ToString();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand checkLogins = new SqlCommand("check_email_password", conn);
                checkLogins.CommandType = System.Data.CommandType.StoredProcedure;
                checkLogins.Parameters.AddWithValue("@Email", login.Email);
                checkLogins.Parameters.AddWithValue("@Password", EncryptedPassword(login.Password));
            
                int Variable = (int)checkLogins.ExecuteScalar();
                conn.Close();
                if (Variable == 1)
                {
                   
                    var getbyemail = GetByEmail(login.Email);

                   Console.WriteLine(login);
                   
                    
                   
                    var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                    var KEY = Encoding.UTF8.GetBytes(_appsettings.Value.Key);

                    var issuer = _jwt.Value.ValidIssuer;
                    var audience = _jwt.Value.ValidAudience;
                    var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
                    var refreshTokenValidityInMinutes = _jwt.Value.RefreshTokenValidityInMinutes;

                    var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                    {



                        //Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                        //{
                        //    new Claim(ClaimTypes.Name, login.Email.ToString()),
                        //    new Claim("Id", Guid.NewGuid().ToString()),
                        //    new Claim(ClaimTypes.Role,  getbyemail.Register.Role.ToString()),

                        //    new Claim(JwtRegisteredClaimNames.Sub,  login.Email),
                        //    new Claim(JwtRegisteredClaimNames.Email, login.Email),
                        //    new Claim(JwtRegisteredClaimNames.Jti,
                        //    Guid.NewGuid().ToString())

                        //}),
                        //Expires = DateTime.UtcNow.AddMinutes(10),
                        //Issuer = _configuration["JWT:ValidIssuer"],
                        //Audience = _configuration["JWT:ValidAudience"],


                        Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, login.Email.ToString()),
                            new Claim("Id", Guid.NewGuid().ToString()),
                            new Claim(ClaimTypes.Role, getbyemail.Register.Role.ToString()),

                            new Claim(JwtRegisteredClaimNames.Sub,  login.Email),
                            new Claim(JwtRegisteredClaimNames.Email, login.Email),
                            new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                   
                    
                }),
                        Expires = DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                        Issuer = issuer,
                        Audience = audience,
                        
                        SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(KEY), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)


                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var refreshToken = RefreshTokenGenerator();

                     
                    //_ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMinutes);

                    var Token = tokenHandler.WriteToken(token);
                    TokenModel model = new TokenModel();
                    model.RefreshToken = refreshToken;
                    model.ExpireRefreshTokenTime = DateTime.UtcNow.AddMinutes(refreshTokenValidityInMinutes);

                    model.AccessToken = Token;


                    response.Token = model;
                    response.Login = login;
                    response.StatusCode = 200;
                    response.StatusMessage = "Login Successful";

                    _httpContextAccessor.HttpContext.Response.Cookies.Append("token", Token, new CookieOptions()
                    {
                        Expires = DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                        //HttpOnly = true,
                        //Secure = true,
                        //IsEssential = true,
                        //SameSite = SameSiteMode.None

                         HttpOnly = true,
                        SameSite = SameSiteMode.Strict
                    });


                    _httpContextAccessor.HttpContext.Response.Cookies.Append("X-Refresh-Token", refreshToken, new CookieOptions() {  HttpOnly = true, SameSite = SameSiteMode.Strict });
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("X-Username", login.Email, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
                    
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "Invalid UserName or Password";
                }
                return response;
            }

        }

        // generate refresh token
        private static string RefreshTokenGenerator()
        {
            var randomNumber = new byte[640];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        // register user details
        public Response Register(RegisterModel register)
        {
            Response resposne = new Response(); 
            string connection = _config.Value.SNCon.ToString();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand checkEmail = new SqlCommand("check_email_register", conn);

                checkEmail.CommandType = System.Data.CommandType.StoredProcedure;
                checkEmail.Parameters.AddWithValue("@Email", register.Email);
              
               string email = (string)checkEmail.ExecuteScalar();
                if(email == register.Email)
                {
                   resposne.StatusCode = 400;
                    resposne.StatusMessage = "Email id already existed";
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Usp_Register", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", register.UserName);
                    cmd.Parameters.AddWithValue("@Email", register.Email);

                    // without encypted password
                    // cmd.Parameters.AddWithValue("@Password", register.Password); EncryptSha256Password

                    cmd.Parameters.AddWithValue("@Password", EncryptedPassword(register.Password));
                    cmd.Parameters.AddWithValue("Role",register.Role.ToString());
                    
                   // cmd.Parameters.AddWithValue("@Password", EncryptSha256Password(register.Password));

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                   RegisterModel model = new RegisterModel();
                    if (i > 0)
                    {
                        model.UserName= register.UserName;
                        model.Email= register.Email;    
                        model.Password= register.Password;
                        resposne.StatusCode = 200;
                        resposne.StatusMessage = "Successfully registered";
                        resposne.Register = model;
                    }
                    else
                    {
                        resposne.StatusCode = 400;
                        resposne.StatusMessage = "Registration has been failed";
                        resposne.Register = null;
                    }

                }
                return resposne;

            }
            
        }

        // get refresh token
        //public async Task Refresh([FromBody] TokenModel model)
        //{
        //    Response response = new Response();

        //    string accessToken = model.AccessToken;
        //    string refreshToken = model.RefreshToken;
        //    var principal = GetPrincipalFromExpiredToken(model.AccessToken);
        //    if (principal == null)
        //    {
        //        response.StatusCode = 400;
        //        response.StatusMessage = "Invalid access token or refresh token";
                
        //    }
        //    var username = principal?.Identity?.Name;
        //    // check by username

        //    var newAccessToken = GenerateJwtToken(username);
        //    var newRefreshToken = RefreshTokenGenerator();
        //    model.RefreshToken = newRefreshToken;

        //    var jwtToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken);
        //    model.AccessToken = jwtToken; 
          

        //  await Task.FromResult(response);   
        //}

        // create token:
        private JwtSecurityToken GenerateJwtToken(string username)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
               
            };
            var validIssuer = _jwt.Value.ValidIssuer;
            var ValidAudience = _jwt.Value.ValidAudience;
            var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
            var secret = _configuration["AppSettings:Key"] ?? throw new InvalidOperationException("Secret Key is not configured");
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var token = new JwtSecurityToken(
                

                issuer:validIssuer,
                audience:ValidAudience,
                expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                claims:authClaims,
                signingCredentials:new SigningCredentials(Key,SecurityAlgorithms.HmacSha256)

                );
              return token;
        }

        //GetPrincipalFromExpiredToken:
        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var secret = _configuration["AppSettings:Key"] ?? throw new InvalidOperationException("Secret Key is not configured");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters,out SecurityToken securityToken);
         

            if(securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid Token");
            return principal;
        }

        // refresh  token
        public Response Refresh([FromBody] TokenModel model)
        {
            Response response = new Response();

            //string accessToken = model.AccessToken;
            //string refreshToken = model.RefreshToken;


   
         
          
            
            string connection = _config.Value.SNCon.ToString();
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();


                var principal = GetPrincipalFromExpiredToken(model.AccessToken);
                if (principal == null)
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "Invalid access token or refresh token";

                }

                var username = principal?.Identity?.Name;
                // var user = GetByEmail(username);
                // check by username

                SqlCommand checkEmail = new SqlCommand("check_email_register", conn);
                checkEmail.CommandType = CommandType.StoredProcedure;
                checkEmail.Parameters.AddWithValue("@Email", username);
                string email = (string)checkEmail.ExecuteScalar();
                
                conn.Close();

                if (email != username)
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "Invalid access token or Invalid refresh token";
                } else
                {
                    var newAccessToken = GenerateJwtToken(username);
                    var newRefreshToken = RefreshTokenGenerator();
                    model.RefreshToken = newRefreshToken;

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken);
                    model.AccessToken = jwtToken;
                    model.ExpireRefreshTokenTime = DateTime.UtcNow.AddMinutes(_jwt.Value.RefreshTokenValidityInMinutes);
                    if (model.AccessToken != null)
                    {
                        response.StatusCode = 200;
                        response.StatusMessage = "Refresh successfully..";

                        response.Token = model;
                    }
                }
                 


               

                _httpContextAccessor.HttpContext.Response.Cookies.Append("token", model.AccessToken, new CookieOptions()
                {
                    Expires = DateTime.UtcNow.AddMinutes(_jwt.Value.TokenValidityInMinutes),
                    //HttpOnly = true,
                    //Secure = true,
                    //IsEssential = true,
                    //SameSite = SameSiteMode.None

                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });


                _httpContextAccessor.HttpContext.Response.Cookies.Append("X-Refresh-Token", model.RefreshToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
                _httpContextAccessor.HttpContext.Response.Cookies.Append("X-Username", username, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });



                return response;
            }   

           
        }


        // encrypted password
        public static string EncryptedPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }
            else
            {
                byte[]  passwordBase64 = ASCIIEncoding.ASCII.GetBytes(password);    
                string  encryptPassword = Convert.ToBase64String(passwordBase64);
                return encryptPassword;
            }
        }

        // decrypted password
        public static string DecryptedPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }
            else
            {
                byte[] encryptPassword = Convert.FromBase64String(password);
                string DecryptedPassword = ASCIIEncoding.ASCII.GetString(encryptPassword);
                return DecryptedPassword;
            }
        }


        // sha256 password:

        public static string EncryptSha256Password(string password)
        {
           using var sha256 = SHA256.Create();
            byte[] hashPassword = Encoding.UTF8.GetBytes(password);
            byte[] EncryptPasswordstorage = sha256.ComputeHash(hashPassword);
            return Convert.ToBase64String(EncryptPasswordstorage);
        }



       


    }
}