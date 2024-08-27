namespace JWTRoleAuthentication.CommonLayer.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
       
    }
    public class LoginResponse
    {
        public int StatusCode { get; set; } 
        public string StatusMessage { get; set; }
        public TokenModel TokenModel { get; set; }
    }
}
