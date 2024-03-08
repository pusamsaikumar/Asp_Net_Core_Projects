using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using RSAMobileAPI.RSADALayer;
using RSAMobileAPI.RSAEntities;

using RSAMobileAPI.RSARepositories.Interfaces;
using static RSAMobileAPI.RSAEntities.GetClientStoreForAppResponse;

namespace RSAMobileAPI.RSARepositories.Services
{
    public class CustomerMgr : ICustomerMgr
    {
        private readonly CustomerDA _customerDA;

        public CustomerMgr(CustomerDA customerDA)
        {
            _customerDA = customerDA;
        }



        public List<GetClientStores_Result> GetClientStores(int ClientStoreId)
        {
           return _customerDA.GetClientStores(ClientStoreId);
        }

        public List<GetClientStores_App_Result> GetClientStoresForApp(int ClientStoreId)
        {
            return _customerDA.GetClientStoresForApp(ClientStoreId);


        }
    }
}
