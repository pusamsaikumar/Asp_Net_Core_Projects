using JWTRoleAuthentication.CommonLayer.Models;

namespace JWTRoleAuthentication.JWTDAL
{
    public interface IAuthRepo
    {
        Task<RegisterResponse> SignUp(Register register);
        Task<RegisterResponse> GetUserDetails(string userName);
        Task<RegisterResponse> GetTokensFromDB(string userName);
        Task<LoginResponse> Login(LoginModel model);
        Task<TokenResponse> GetTokenRefreshTokenById(string userId);
        Task<TokenResponse> Refresh(TokenModel model);
        Task<TokenResponse> UpdateTokenToDB(TokenModel model, string userId);

        Task<ResponseDataTypes> InsertSampleData(SampleDataTypes model);
    }
}
