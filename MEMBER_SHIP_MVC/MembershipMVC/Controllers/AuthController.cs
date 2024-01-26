using MembershipMVC.Data;
using MembershipMVC.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using System.Web.Helpers;

namespace MembershipMVC.Controllers
     
{
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
   
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDBContext _db;
        private readonly IConfiguration _config;

        public AuthController(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           ApplicationDBContext db,
           IConfiguration config

           )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _config = config;
        }




        [AllowAnonymous]
        [HttpGet("getToken")]
        public async Task<IActionResult> GetToken( Login login)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == login.Username);

            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

                if (signInResult.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_config.GetSection("Keys")["TokenSigningKey"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {  
                            new Claim(ClaimTypes.Name,user.Id.ToString()),
                            new Claim(ClaimTypes.Name, login.Username)
                        }),
                        Expires = DateTime.UtcNow.AddDays(30),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                     return Ok(new { Token = tokenString });
                    
                }
            }
            return BadRequest();
        }

        [HttpGet("getResources")]
        public IActionResult GetResources()
        {
            return Ok(new { Data = "THIS IS THE DATA THAT IS PROTECTED BY AUTHORIZATION" });
        }
    }
}
