using JWTRoleAuthentication.CommonLayer.Models;
using JWTRoleAuthentication.JWTDAL;

namespace JWTRoleAuthentication.JWTBLL
{
    public class FileService : IFileService
    {
        private readonly IFileRepo _fileRepo;

        public FileService(IFileRepo fileRepo)
        {
            _fileRepo = fileRepo;
        }
        public async Task<CustomerResponse> AddCustomerWithJsonfile(string sharedKey, string secretKey, CustomerModel model)
        {
            var result = await _fileRepo.AddCustomerWithJsonfile(sharedKey,secretKey,model);
            return result;
            
        }

        public async Task<LoginResponse> LoginWithJSONFile(string sharedKey, string secretKey, LoginModel model)
        {
            var result = await _fileRepo.LoginWithJSONFile(sharedKey,secretKey,model);
            return result;
        }

        public async Task<RSAClinetResponse> ReadJsonFile(string sharedKey, string secretKey)
        {
            var result = await _fileRepo.ReadJsonFile(sharedKey, secretKey);
            return result;
        }
        public async Task<CouponResponse> GetCouponsData()
        {
             var result = await _fileRepo.GetCouponsData();
            return result;
        }

        }
}
