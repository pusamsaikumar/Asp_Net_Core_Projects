using JWTRoleAuthentication.CommonLayer.Models;

namespace JWTRoleAuthentication.JWTDAL
{
    public interface IFileRepo
    {
        Task<RSAClinetResponse> ReadJsonFile(string sharedKey, string secretKey);
        
        Task<CustomerResponse> AddCustomerWithJsonfile(string sharedKey,string secretKey, CustomerModel model);
        Task<LoginResponse> LoginWithJSONFile(string sharedKey,string secretKey, LoginModel model);
        Task<CouponResponse> GetCouponsData();
    }
}
