namespace JWTRoleAuthentication.CommonLayer.Models
{
    public class AppSettings
    {
      

        public string Key { get; set; }
    }
    public class ConnectionStrings
    {
        public string AuthDBCon { get; set; }
        public string AzureDBCon { get;set; }
    }
    public class JWT
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
        public int TokenValidityInMinutes { get; set; }
        public int RefreshTokenValidityInMinutes { get; set; }
        public string Key { get; set; }
         public string Issuer { get; set; }
   


    }

}

