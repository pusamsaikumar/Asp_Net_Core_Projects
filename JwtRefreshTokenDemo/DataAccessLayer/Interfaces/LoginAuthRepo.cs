using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class LoginAuthRepo : ILoginAuthRepo
    {
        public Task<Response> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Login(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public Task<Response> RefreshToken(TokenModel tokenModel)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Register(RegisterModel registerModel)
        {
            throw new NotImplementedException();
        }
    }
}
