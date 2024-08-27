using BusinessLogicLayer;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtRefreshTokenDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginAuthService _loginAuthService;

        public AccountController(ILoginAuthService  loginAuthService)
        {
            _loginAuthService = loginAuthService;
        }
        [HttpGet]
        public IActionResult GeResult()
        {
            return Ok("hellow");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            return Ok();
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            return Ok();    
        }
        [HttpPost]
        [Route("Refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            return Ok();
        }
        [HttpGet]
        [Route("GetByEmailId")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok();
        }
    }
}
