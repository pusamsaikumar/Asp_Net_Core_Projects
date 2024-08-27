using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ILoginAuthRepo
    {
        Task<Response> Login(LoginModel loginModel);
        Task<Response> Register(RegisterModel registerModel);
        Task<Response> GetByEmail(string email);  
        Task<Response> RefreshToken(TokenModel tokenModel);
    }
}
