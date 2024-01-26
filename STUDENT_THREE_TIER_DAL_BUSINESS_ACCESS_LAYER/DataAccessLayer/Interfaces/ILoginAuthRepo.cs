using CommonLayer.Models;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ILoginAuthRepo
    {
        // bool 
        //bool Register(RegisterModel register);
      // Task<RegisterModel> GetByEmail(string email);
        public Response Register(RegisterModel register);
      
        Response Login(LoginModel login);

        Response GetByEmail(string email);
        Response Refresh([FromBody] TokenModel model);
    }
}
