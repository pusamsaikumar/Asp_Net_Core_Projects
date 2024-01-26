using CommonLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public LoginAuthService(ILoginAuthRepo repo)
        {
            _repo = repo;
        }

        public Response GetByEmail(string email)
        {
            var result = _repo.GetByEmail(email);
           return result;   
        }

        public Response Login(LoginModel login)
        {
           var result = _repo.Login(login);
            return result;  
        }

        public Response Refresh([FromBody] TokenModel model)
        {
           var result = _repo.Refresh(model);
            return result;  
        }

        public Response Register(RegisterModel register)
        {
            var result = _repo.Register(register);
            return result;
        }
    }
}
