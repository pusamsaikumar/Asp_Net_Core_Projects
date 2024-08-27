using JWTRoleBaseAuthentication.CommonLayer.Models;
using JWTRoleBaseAuthentication.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JWTRoleBaseAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
       
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IAuthRepo _authService;

            private readonly Helpers _helpers;
            private readonly IOptions<JWT> _jwt;

            public AccountController(
                IHttpContextAccessor httpContextAccessor,
                IAuthRepo authService,

                Helpers helpers,
                IOptions<JWT> jwt

                )
            {
                _httpContextAccessor = httpContextAccessor;
                _authService = authService;

                _helpers = helpers;
                _jwt = jwt;
            }

            [HttpGet]
            [Route("GetUserDetails")]
            public async Task<RegisterResponse> GetUserDetails(string UserName)
            {
                RegisterResponse response = new RegisterResponse();
                response.Register = new Register();
                try
                {
                    var user = await _authService.GetUserDetails(UserName);
                    response.Register = user.Register;
                    response.StatusCode = 200;
                    response.StatusMessage = "Successfully retrived user details";

                }
                catch (Exception ex)
                {
                    response.StatusCode = 500;
                    response.StatusMessage = "Something went wrong.";
                }
                return response;
            }
            [HttpPost]
            [Route("SignUp")]
            public async Task<RegisterResponse> SignUp(Register register)
            {
                RegisterResponse registerResponse = null;
                registerResponse = new RegisterResponse();
                registerResponse.Register = new Register();
                try
                {
                    var result = await _authService.SignUp(register);

                    registerResponse.Register = result.Register;
                    registerResponse.StatusCode = result.StatusCode;
                    registerResponse.StatusMessage = result.StatusMessage;
                }
                catch (Exception ex)
                {
                    registerResponse.StatusCode = 500;
                    registerResponse.StatusMessage = "Something went wrong.";
                }
                return registerResponse;
            }
            [HttpPost]
            [Route("Login")]
            public async Task<IActionResult> Login(LoginModel model)
            {
                var result = await _authService.Login(model);
                if (result.StatusCode != 200)
                {
                    return BadRequest(new { message = result.StatusMessage });
                }
                var response = new LoginResponse();
                response.TokenModel = result.TokenModel;
                response.StatusMessage = result.StatusMessage;
                response.StatusCode = result.StatusCode;
                return Ok(response);
            }

        }
    }
