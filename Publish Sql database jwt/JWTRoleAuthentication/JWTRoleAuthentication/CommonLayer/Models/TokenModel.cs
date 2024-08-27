namespace JWTRoleAuthentication.CommonLayer.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
       // public DateTime RefreshTokenExpiresIn { get; set; }
      //  public string UserID { get; set; }  
    }
    public class TokenResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public TokenModel TokenModel { get; set; }
    }
}
