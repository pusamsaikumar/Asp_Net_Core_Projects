using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RSAMobileAPI.RSADALayer;
using static RSAMobileAPI.RSAEntities.GetClientStoreForAppResponse;

namespace RSAMobileAPI.RSADALayer
{
    public class CustomerDA
    {
        private readonly RSA_QAEntities _rSADBcontext;

        public CustomerDA(RSA_QAEntities rSADBcontext)
        {
            _rSADBcontext = rSADBcontext;
        }

        
        public List<GetClientStores_Result> GetClientStores(int ClientStoreId)
        {
            var clientStoreIdParameter = new SqlParameter("@ClientStoreId", ClientStoreId);

            var clientData = _rSADBcontext.Set<GetClientStores_Result>().FromSqlRaw("EXEC GetClientStores @ClientStoreId ", clientStoreIdParameter).ToList();

            return clientData;

        }
         public List<GetClientStores_App_Result> GetClientStoresForApp(int ClientStoreId)
         {

        var clientStoreIdParameter = new SqlParameter("@ClientStoreId", ClientStoreId );

            // NEED PROC: EXEC GetClientStores_App @ClientStoreId
            var clientData = _rSADBcontext.Set<GetClientStores_App_Result>().FromSqlRaw("EXEC GetClientStores_App @ClientStoreId ", clientStoreIdParameter).ToList();



             return clientData;


         }
    }
    //  public class CustomerDA : BaseDA
    //  {

    //public List<GetClientStores_Result> GetClientStores(int ClientStoreId)
    //{
    //    var clientStoreIdParameter = new SqlParameter("@ClientStoreId", ClientStoreId);

    //    var clientData = dbContext.Set<GetClientStores_Result>().FromSqlRaw("EXEC GetClientStores @ClientStoreId ", clientStoreIdParameter).ToList();

    //    return clientData;

    //}


    // public List<GetClientStores_App_Result> GetClientStoresForApp(int ClientStoreId)
    // {

    //var clientStoreIdParameter = new SqlParameter("@ClientStoreId", ClientStoreId );

    //var clientData = dbContext.Set<GetClientStores_App_Result>().FromSqlRaw("EXEC GetClientStores @ClientStoreId ", clientStoreIdParameter).ToList();



    //     return clientData;


    // }
    // }
}


