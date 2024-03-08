
using RSAMobileAPI.RSADALayer;
using static RSAMobileAPI.RSAEntities.GetClientStoreForAppResponse;

namespace RSAMobileAPI.RSARepositories.Interfaces
{
    public interface ICustomerMgr
    {
       List<GetClientStores_Result> GetClientStores(int ClientStoreId);
        List<GetClientStores_App_Result> GetClientStoresForApp(int ClientStoreId);
       
    }   
}
