using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using RSAMobileAPI.RSAEntities;
using RSAMobileAPI.RSADALayer;

namespace RSAMobileAPI.RSADALayer
{
    public class BaseDA : IDisposable
    {
        private static IOptions<AppSettings>? _appsettings;
        //private readonly RSA_QAEntities dbcontext;

        public BaseDA(IOptions<AppSettings> appsettings)
        {
            _appsettings = appsettings;
          //  this.dbcontext = dbcontext;
        }


       // public string Connection_String =_appsettings.Value.MPMDbConnectionString.ToString() ;
        
        //@"Data Source=172.31.0.26\SQLDEV;Initial Catalog=RSAMPM;User Id=RetailSolutionsWebUser;Password=RSA@123;";
        // System.Configuration.ConfigurationManager.ConnectionStrings["MPMConnection"].ConnectionString;
        //@"Data Source=172.31.0.26\SQLDEV;Initial Catalog=RSAMPM;User Id=RetailSolutionsWebUser;Password=RSA@123;";
        //System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
       // public String TOKEN_EXPIRATION_TIME_IN_MINUTES = _appsettings.Value.TOKEN_EXPIRATION.ToString() ;
        //System.Configuration.ConfigurationManager.AppSettings["TOKEN_EXPIRATION"];
       // public RSA_QAEntities dbContext = new RSA_QAEntities();

        public IOptions<AppSettings> Appsettings { get; }

        public BaseDA()
        {
          //  dbContext = new RSA_QAEntities();
        }
        public void Dispose()
        {
            
        }
    }
}
