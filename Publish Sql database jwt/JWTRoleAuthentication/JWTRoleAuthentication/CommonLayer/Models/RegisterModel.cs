namespace JWTRoleAuthentication.CommonLayer.Models
{
    public class Register
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ZipCode { get; set; }
        public string MobileNumber { get; set; }
        public int StoreID { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
     //   public DateTime? RefreshTokenExpires { get; set; }   
    }
    public class RegisterResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Register Register{ get; set; }
    }

}

