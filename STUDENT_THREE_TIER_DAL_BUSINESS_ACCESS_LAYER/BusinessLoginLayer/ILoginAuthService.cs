using CommonLayer.Models;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ILoginAuthService
    {
        Response Register(RegisterModel register);
        Response Login(LoginModel login);
        Response Refresh([FromBody] TokenModel model);
        Response GetByEmail(string email);

    }
}
