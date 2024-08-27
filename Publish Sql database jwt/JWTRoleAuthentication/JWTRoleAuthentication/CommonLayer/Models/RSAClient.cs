namespace JWTRoleAuthentication.CommonLayer.Models
{
    public class RSAClient
    {
        public int RSAClientId { get; set; }  
        public string RSAClientName { get; set; }
        public string Stores { get;set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string SharedKey { get; set; }
        public string SecretKey { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

    }
   
    public class RSAClientData
    {
        public List<RSAClient> RSAClients { get; set;}
    }
    public class RSAClientDataWrapper
    {
        public List<RSAClient> RSAClientData { get; set; }
    }
    public class RSAClinetResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public RSAClient RSAClient { get; set; }
        public AuthDBCon AuthDBCon { get; set; }    
    }
}
