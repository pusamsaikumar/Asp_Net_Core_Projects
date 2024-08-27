using CommonLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class LoginAuthService : ILoginAuthService
    {
        private readonly ILoginAuthRepo _repo;

        public LoginAuthService(ILoginAuthRepo loginAuthRepo)
        {
            _repo = loginAuthRepo;
        }
        public async Task<Response> GetByEmail(string email)
        {
           
           var  result =  await _repo.GetByEmail(email);
            return result;
        }

        public async Task<Response> Login(LoginModel loginModel)
        {
            var result = await _repo.Login(loginModel);
            return result;
        }

        public async Task<Response> RefreshToken(TokenModel tokenModel)
        {
            var result = await _repo.RefreshToken(tokenModel);
            return result;
        }

        public async Task<Response> Register(RegisterModel registerModel)
        {
            var result = await _repo.Register(registerModel);

            return result;
        }
    }
}
