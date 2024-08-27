using JWTRoleAuthentication.CommonLayer.Models;
using JWTRoleAuthentication.JWTDAL;

namespace JWTRoleAuthentication.JWTBLL
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepo _authRepo;

        public AuthService(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }
        public async Task<RegisterResponse> SignUp(Register register)
        {
            var result = await _authRepo.SignUp(register);
            return result;
            
        }
        public async Task<RegisterResponse> GetUserDetails(string userName)
        {
            var result = await _authRepo.GetUserDetails(userName);
            return result;  
        }

        public async Task<LoginResponse> Login(LoginModel model)
        {
            var result = await _authRepo.Login(model);
            return result;
        }

        public async Task<TokenResponse> Refresh(TokenModel model)
        {
            var result = await _authRepo.Refresh(model);
            return result;
        }

        public async Task<ResponseDataTypes> InsertSampleData(SampleDataTypes model)
        {
            var result = await _authRepo.InsertSampleData(model);
            return result;
        }
        }
}
