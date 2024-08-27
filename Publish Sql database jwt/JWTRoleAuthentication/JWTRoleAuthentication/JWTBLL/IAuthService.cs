using JWTRoleAuthentication.CommonLayer.Models;

namespace JWTRoleAuthentication.JWTBLL
{
    public interface IAuthService
    {
        Task<RegisterResponse> SignUp(Register register);
        Task<RegisterResponse> GetUserDetails(string userName);
        Task<LoginResponse> Login(LoginModel model);
        Task<TokenResponse> Refresh(TokenModel model);
        Task<ResponseDataTypes> InsertSampleData(SampleDataTypes model);
        
        }
}
