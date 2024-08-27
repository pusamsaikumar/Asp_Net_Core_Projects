using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JWTRoleBaseAuthentication.CommonLayer.Models
{
    public class Helpers
    {
        private readonly IOptions<JWT> _jwt;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceProvider _serviceProvider;

        public Helpers(
               IOptions<JWT> jwt,
               IServiceProvider serviceProvider,
               IHttpContextAccessor httpContextAccessor
            )
        {
            _jwt = jwt;

            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
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
        public string DecryptedPassword(string password)
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
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));

            // var secret = _configuration["AppSettings:Key"] ?? throw new InvalidOperationException("Secret Key is not configured");
            // var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            // var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);


            var validIssuer = _jwt.Value.ValidIssuer;
            var ValidAudience = _jwt.Value.ValidAudience;
            var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
            var secret = _jwt.Value.Secret;
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var token = new JwtSecurityToken(


                issuer: validIssuer,
                audience: ValidAudience,
                expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateJwtAccessToken(string username)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            using var scope = _serviceProvider.CreateScope();
            //var _repo = scope.ServiceProvider.GetRequiredService<IAuthRepo>();
            //   var user = _repo.GetByEmail(username);
            var authClaims = new List<Claim>
            {
                //new Claim(ClaimTypes.Name, user.Register.Email),
                //new Claim(ClaimTypes.Email, username),
                //new Claim("Id", user.Register.Id.ToString()),
                //new Claim("Role", user.Register.Role),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var validIssuer = _jwt.Value.ValidIssuer;
            var validAudience = _jwt.Value.ValidAudience;
            var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
            var secret = _jwt.Value.Secret;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var token = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return tokenHandler.WriteToken(token);
        }

        public JwtSecurityToken GenerateJwtToken(string username)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            using var scope = _serviceProvider.CreateScope();
           // var _repo = scope.ServiceProvider.GetRequiredService<IAuthRepo>();
            // var user = _repo.GetByEmail(username);
            var authClaims = new List<Claim>
            {
                //new Claim(ClaimTypes.Name, user.Register.Email),
                //new Claim(ClaimTypes.Email, username),
                //new Claim("Id", user.Register.Id.ToString()),
                //new Claim("Role", user.Register.Role),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var validIssuer = _jwt.Value.ValidIssuer;
            var validAudience = _jwt.Value.ValidAudience;
            var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
            var secret = _jwt.Value.Secret;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var token = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }

        public string GenerateJwtToken(string userName, string email, int storeId, DateTime dateOfBirth, string role)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            using var scope = _serviceProvider.CreateScope();
          //  var _repo = scope.ServiceProvider.GetRequiredService<IAuthRepo>();
            //   var user = _repo.GetByEmail(username);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userName ),
                new Claim(ClaimTypes.Email, email),
                new Claim("StoreId", storeId.ToString()),
                new Claim("DateOfBirth",dateOfBirth.ToString("dd-MM-yyyy")),
                new Claim(ClaimTypes.Role, role),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var claimslist = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim("DateOfBirth", dateOfBirth.ToString("yyyy-MM-dd")),
             new Claim("StoreId", storeId.ToString()),
        };



            var validIssuer = _jwt.Value.ValidIssuer;
            var validAudience = _jwt.Value.ValidAudience;
            var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
            var secret = _jwt.Value.Secret;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var token = new JwtSecurityToken(
               issuer: validIssuer,
                audience: validAudience,
                expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                claims: claimslist,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[640];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

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

        //public string GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomNumber);
        //        return Convert.ToBase64String(randomNumber);
        //    }
        //}
    }
}
