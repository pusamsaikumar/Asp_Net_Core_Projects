namespace JWTRoleBaseAuthentication.CommonLayer.Models
{
    public class AppSettings
    {
    }
    public class ConnectionStrings
    {
        public string AuthDBCon { get; set; }
    }
    public class JWT
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
        public int TokenValidityInMinutes { get; set; }
        public int RefreshTokenValidityInMinutes { get; set; }


    }
}
