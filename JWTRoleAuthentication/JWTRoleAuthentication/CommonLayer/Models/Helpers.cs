using JWTRoleAuthentication.JWTDAL;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JWTRoleAuthentication.CommonLayer.Models
{
    public class Helpers
    {
        private readonly IOptions<JWT> _jwt;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<AppSettings> _appsettings;
        private readonly IConfiguration _configuration;
        private readonly IOptions<ConnectionStrings> _config;
        private readonly IServiceProvider _serviceProvider;
        private readonly SqlHelpers _sqlHelpers;

        public Helpers(
               IOptions<JWT> jwt,
               IServiceProvider serviceProvider,
               IHttpContextAccessor httpContextAccessor,
               IOptions<AppSettings> appsettings,
               IConfiguration configuration,
               IOptions<ConnectionStrings> config
            )
        {
            _jwt = jwt;

            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
            _appsettings = appsettings;
            _configuration = configuration;
            _config = config;
            _sqlHelpers = new SqlHelpers(_config.Value.AuthDBCon.ToString());
        }

        // encrypted password
        public string EncryptedPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }
            else
            {
                byte[] passwordBase64 = ASCIIEncoding.ASCII.GetBytes(password);
                string encryptPassword = Convert.ToBase64String(passwordBase64);
                return encryptPassword;
            }
        }

        // decrypted password
        public  string DecryptedPassword(string password)
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

        public string EncryptSha256Password(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] hashPassword = Encoding.UTF8.GetBytes(password);
            byte[] EncryptPasswordstorage = sha256.ComputeHash(hashPassword);
            return Convert.ToBase64String(EncryptPasswordstorage);
        }
        //public string GenerateAccessToken(IEnumerable<Claim> claims)
        //{
        //    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));

        //    // var secret = _configuration["AppSettings:Key"] ?? throw new InvalidOperationException("Secret Key is not configured");
        //    // var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        //    // var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);


        //    var validIssuer = _jwt.Value.ValidIssuer;
        //    var ValidAudience = _jwt.Value.ValidAudience;
        //    var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
        //    var secret = _jwt.Value.Secret;
        //    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        //    var token = new JwtSecurityToken(


        //        issuer: validIssuer,
        //        audience: ValidAudience,
        //        expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
        //        claims: claims,
        //        signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)

        //        );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //public string GenerateJwtAccessToken(string username)
        //{
        //    var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        //    using var scope = _serviceProvider.CreateScope();
        //    var _repo = scope.ServiceProvider.GetRequiredService<IAuthRepo>();
        //    //   var user = _repo.GetByEmail(username);
        //    var authClaims = new List<Claim>
        //    {
        //        //new Claim(ClaimTypes.Name, user.Register.Email),
        //        //new Claim(ClaimTypes.Email, username),
        //        //new Claim("Id", user.Register.Id.ToString()),
        //        //new Claim("Role", user.Register.Role),
        //        //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    };
        //    var validIssuer = _jwt.Value.ValidIssuer;
        //    var validAudience = _jwt.Value.ValidAudience;
        //    var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
        //    var secret = _jwt.Value.Secret;
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        //    var token = new JwtSecurityToken(
        //        issuer: validIssuer,
        //        audience: validAudience,
        //        expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        //    );
        //    return tokenHandler.WriteToken(token);
        //}

        //public JwtSecurityToken GenerateJwtToken(string username)
        //{
        //    var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        //    using var scope = _serviceProvider.CreateScope();
        //    var _repo = scope.ServiceProvider.GetRequiredService<IAuthRepo>();
        //    // var user = _repo.GetByEmail(username);
        //    var authClaims = new List<Claim>
        //    {
        //        //new Claim(ClaimTypes.Name, user.Register.Email),
        //        //new Claim(ClaimTypes.Email, username),
        //        //new Claim("Id", user.Register.Id.ToString()),
        //        //new Claim("Role", user.Register.Role),
        //        //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    };
        //    var validIssuer = _jwt.Value.ValidIssuer;
        //    var validAudience = _jwt.Value.ValidAudience;
        //    var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
        //    var secret = _jwt.Value.Secret;
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        //    var token = new JwtSecurityToken(
        //        issuer: validIssuer,
        //        audience: validAudience,
        //        expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        //    );
        //    return token;
        //}

        //    public string GenerateJwtToken(string userName, string email, int storeId, DateTime dateOfBirth, string role)
        //    {


        //        var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();


        //        var authClaims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, userName),
        //    new Claim(ClaimTypes.Email, email),
        //    new Claim(ClaimTypes.Role,role.ToString()),
        //    new Claim("DateOfBirth", dateOfBirth.ToString("dd-MM-yyyy")),
        //    new Claim("StoreId", storeId.ToString()),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //};
        //        var validIssuer = _jwt.Value.ValidIssuer;
        //        var validAudience = _jwt.Value.ValidAudience;
        //        var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;

        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Value.Secret.ToString()));
        //        var token = new JwtSecurityToken(
        //            issuer: validIssuer,
        //            audience: validAudience,
        //            expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
        //            claims: authClaims,
        //            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        //        );
        //        return tokenHandler.WriteToken(token);
        //    }
        public string GenerateJwtToken(string userName, string email, int storeId, DateTime dateOfBirth, string role)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, userName),
        new Claim(ClaimTypes.Email, email),
        new Claim(ClaimTypes.Role, role),
        new Claim("DateOfBirth", dateOfBirth.ToString("dd-MM-yyyy")),
        new Claim("StoreId", storeId.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Value.Secret));
            var token = new JwtSecurityToken(
                _jwt.Value.ValidIssuer,
                _jwt.Value.ValidAudience,
                expires: DateTime.UtcNow.AddMinutes(_jwt.Value.TokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            ); 
            return tokenHandler.WriteToken(token);
        }

        //public string GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[640];
        //    using var generator = RandomNumberGenerator.Create();
        //    generator.GetBytes(randomNumber);
        //    return Convert.ToBase64String(randomNumber);
        //}

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var secret = _jwt.Value.Secret;
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);


            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid Token");
            return principal;
        }

        //  public string GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomNumber);
        //        return Convert.ToBase64String(randomNumber);
        //    }
        //}


        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomNum = RandomNumberGenerator.Create())
            {
                randomNum.GetBytes(randomNumber);
            }
            var randomValue = Convert.ToBase64String(randomNumber);                          
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Value.Secret);
            // Create an array of claims
            var claims = new[]
            {
                new Claim("randomValue", randomValue)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_jwt.Value.RefreshTokenValidityInMinutes),
                
                      
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = tokenHandler.WriteToken(securityToken);

            return refreshToken;
        }
        public bool IsTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            return jwtToken.ValidTo < DateTime.UtcNow;
        }
        public bool IsRefreshTokenExpired(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtRefreshToken = tokenHandler.ReadToken(refreshToken);
            return jwtRefreshToken.ValidTo < DateTime.UtcNow;
        }
        public async Task<int> ValidateDBToken(string token)
        {

            var storedProcName = "ValidateDBToken";
            var tokenParameter = new SqlParameter("@Token", token);
            int tokenExist = await _sqlHelpers.ExecuteIntScalar(storedProcName,tokenParameter);
            if (tokenExist > 0)
            {
                return 1;
            }
            return 0;

            //using (var conn = new SqlConnection(_config.Value.AuthDBCon.ToString()))
            //{
            //    await conn.OpenAsync();

            //    var command = new SqlCommand("ValidateDBToken", conn);
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.Parameters.AddWithValue("@Token", token);

            //    int tokenExists = (int) await command.ExecuteScalarAsync();

            //  await conn.CloseAsync();
            //    if(tokenExists > 0)
            //   {
            //    return 1;
            //   }
            //   return 0;
            //}

        }

        public async Task<TokenModel> GetDBTokenDetailsByToken(string token)
        {

            var storedProcName = "GetDBTokensByToken";
            var tokenParameter = new SqlParameter("@Token", token);
            var user = await _sqlHelpers.GetSingleRow(storedProcName,tokenParameter);
            if (user != null)
            {
                return new TokenModel
                {
                    Token = user["Token"].ToString(),
                    RefreshToken = user["RefreshToken"].ToString()
                    
                };
            }

            //using (var connection = new SqlConnection(_config.Value.AuthDBCon.ToString()))
            //{
            //    await connection.OpenAsync();

            //    var command = new SqlCommand("GetDBTokensByToken", connection);
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.Parameters.AddWithValue("@Token", token);

            //    using (var reader = await command.ExecuteReaderAsync())
            //    {
            //        if (await reader.ReadAsync())
            //        {
            //            return new TokenModel
            //            {
            //                Token = reader["Token"].ToString(),
            //                RefreshToken = reader["RefreshToken"].ToString(),
            //                // UserID = reader["UserID"].ToString()

            //            };
            //        }
            //    }
            //}

            return null;
        }

        //private bool IsTokenExpired(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var jwtToken = tokenHandler.ReadJwtToken(token);
        //    return jwtToken.ValidTo < DateTime.UtcNow;
        //}

       public async Task<string> BuildConnectionString(AuthDBCon authDBCon)
        {
            string connectionString = string.Empty; 
            try
            {
                connectionString = $"Data Source={authDBCon.DataSource};Initial Catalog={authDBCon.InitialCatalog};User ID={authDBCon.UserID};Password={authDBCon.Password}"; 

                // connectionString = "Data Source=" + authDBCon.DataSource + ";Initial Catalog=" + authDBCon.InitialCatalog + ";User ID=" + authDBCon.UserID + ";Password=" + authDBCon.Password;
            }
            catch (Exception ex)
            {
                connectionString = string.Empty;
            }
           // return connectionString;
           return await Task.FromResult(connectionString);
        }


    }


}


