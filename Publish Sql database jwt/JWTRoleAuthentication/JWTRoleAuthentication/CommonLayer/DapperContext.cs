using JWTRoleAuthentication.CommonLayer.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace JWTRoleAuthentication.CommonLayer
{
    public class DapperContext
    {
        private readonly IOptions<ConnectionStrings> _options;
        private readonly string _connectionString;
        public DapperContext(IOptions<ConnectionStrings> options)
        {
            _options = options;
            _connectionString = _options.Value.AuthDBCon.ToString();
        }
        public IDbConnection CreateDBConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
