namespace JWTRoleAuthentication.CommonLayer.Models
{
    public class AuthDBCon
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }

        public string BuildConnectionString()
        {
            // Construct the connection string dynamically
            return $"Data Source={DataSource};Initial Catalog={InitialCatalog};User ID={UserID};Password={Password};";
        }
    }


}
