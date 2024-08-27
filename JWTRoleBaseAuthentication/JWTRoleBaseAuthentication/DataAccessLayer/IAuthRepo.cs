using JWTRoleBaseAuthentication.CommonLayer.Models;

namespace JWTRoleBaseAuthentication.DataAccessLayer
{
    public interface IAuthRepo
    {
        Task<RegisterResponse> SignUp(Register register);
        Task<RegisterResponse> GetUserDetails(string userName);
        Task<RegisterResponse> GetTokensFromDB(string userName);
        Task<LoginResponse> Login(LoginModel model);
    }
}

