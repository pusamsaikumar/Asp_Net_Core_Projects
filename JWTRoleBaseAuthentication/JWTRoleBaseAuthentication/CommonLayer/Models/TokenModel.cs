namespace JWTRoleBaseAuthentication.CommonLayer.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiresIn { get; set; }
    }
}
