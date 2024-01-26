using BusinessLogicLayer;
using CommonLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentThreeTier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginAuthService _loginAuthService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILoginAuthRepo _loginAuthRepo;

        public AccountController(
            ILoginAuthRepo loginAuthRepo,
           ILoginAuthService loginAuthService,
           IHttpContextAccessor httpContextAccessor


            )
        {
            _loginAuthService = loginAuthService;
            _httpContextAccessor = httpContextAccessor;
            _loginAuthRepo = loginAuthRepo;


        }
        [HttpPost]
        [Route("Login")]
       
        public IActionResult Login(LoginModel loginModel)
        {
           var result = _loginAuthService.Login(loginModel);
            if (result.StatusCode != 200)
            {
                return BadRequest(new { message = result.StatusMessage });
            }
            //if(result)
            //{
            //    return Ok(result);
            //}
            //else
            //{
            //    return BadRequest(new { message = "Invalid username or password" });
            //}

            return  Ok(new { result.Token,result.StatusMessage,result.StatusCode});
        }

        

        [HttpPost]
        [Route("RegisterDetails")]
        [Produces("application/json")]
        public IActionResult RegisterDetails(RegisterModel register)
        {
            var result = _loginAuthService.Register(register);
           if(result.StatusCode != 200)
            {
                return BadRequest(new { message = result.StatusMessage});
            }
            
          return  Ok(result);   
        }

        [HttpPost]
        [Route("Refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenModel model)
        {
           
            _ = _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("token", out var token);


            _ = _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("X-Refresh-Token", out var cookieRefreshToken);


             if (token != model.AccessToken || cookieRefreshToken != model.RefreshToken || model.ExpireRefreshTokenTime < DateTime.UtcNow)

            //if ( model.ExpireRefreshTokenTime < DateTime.UtcNow)

            {
                return BadRequest("Invalid  token or refresh credentials");
                // throw new InvalidProgramException("Invalid token credentials");
            }
            var result = _loginAuthService.Refresh(model);
        
            if(result.StatusCode != 200)
            {
                return BadRequest(new {message = result.StatusMessage});
            } 
            return Ok(new { token = result.Token.AccessToken, refreshToken = result.Token.RefreshToken,expire = result.Token.ExpireRefreshTokenTime
        });
            
            
        }


        [HttpGet]
        [Route("GetByEmailId")]

        public async Task<IActionResult> GetByEmailId(string email)
        {
            if(email == null)
            {
                return BadRequest();    
            }
            var result = _loginAuthService.GetByEmail(email);
            if(result.StatusCode != 200) {
                return NotFound("Email Address is not found.");
            }
            return Ok(new {Status = result.StatusCode,Message = result.StatusMessage,Details = result.Register});
        }
    }
}
