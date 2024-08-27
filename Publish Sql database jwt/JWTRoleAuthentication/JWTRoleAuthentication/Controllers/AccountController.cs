using JWTRoleAuthentication.CommonLayer.Models;
using JWTRoleAuthentication.JWTBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace JWTRoleAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;
       
        private readonly Helpers _helpers;
        private readonly IOptions<JWT> _jwt;
        
        public AccountController(
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService,
            
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
                 response.Register =user.Register;
                response.StatusCode = 200;
                response.StatusMessage = "Successfully retrived user details";

            }catch(Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "Something went wrong. Please try again.";
            }
            return response;
        }
        [HttpPost]
        [Route("SignUp")]
        public async  Task<IActionResult> SignUp(Register register)
        {
            var registerResponse = new RegisterResponse();

            var result = await _authService.SignUp(register);

            registerResponse.Register = result.Register;
            registerResponse.StatusCode = result.StatusCode;
            registerResponse.StatusMessage = result.StatusMessage;
            try
            {
                switch (result.StatusCode)
                {
                    case 200:
                        return Ok(registerResponse);
                    case 400:
                        return BadRequest(registerResponse);

                    case 500:

                        return StatusCode(registerResponse.StatusCode, new { StatusCode = 500, StatusMessage = registerResponse.StatusMessage });
                    default:
                        return StatusCode(registerResponse.StatusCode, registerResponse);
                }
            }
            catch(Exception ex)
            {
                   registerResponse.StatusCode = result.StatusCode;
                   registerResponse.StatusMessage = result.StatusMessage;

                   return StatusCode(registerResponse.StatusCode, registerResponse.StatusMessage);
            }    
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var response = new LoginResponse();
            var result = await _authService.Login(model);
            response.TokenModel = result.TokenModel;
            response.StatusMessage = result.StatusMessage;
            response.StatusCode = result.StatusCode;
            try
            {
                switch (result.StatusCode) { 
                    
                    case 200:
                       return Ok(response);
                    case 400:
                        return BadRequest(response);
                    case 500:
                        return StatusCode(response.StatusCode, new {StatusCode = response.StatusCode,StatusMessage = result.StatusMessage});
                    default:
                        return StatusCode(response.StatusCode, response);
                }
                

            }
            catch(Exception ex)
            {
                response.StatusMessage = result.StatusMessage;
                response.StatusCode = result.StatusCode;
                return StatusCode(response.StatusCode, new { StatusCode = response.StatusCode, StatusMessage = response.StatusMessage });
            }
           // return Ok(response);
        }
        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> Refresh(TokenModel model)
        {
            TokenResponse response = new TokenResponse();
       

            int tokenExist = 0;
            if ( model.Token != null)
            {
                tokenExist = await _helpers.ValidateDBToken(model.Token);
            }

            string dbRefreshToken = null;
           
            string dbToken = null;

            if (tokenExist > 0)
            {

                var getTokens = await _helpers.GetDBTokenDetailsByToken(model.Token);

                dbRefreshToken = getTokens.RefreshToken;
               
                dbToken = getTokens.Token;
            }

            if (dbRefreshToken != model.RefreshToken || dbToken != model.Token || _helpers.IsRefreshTokenExpired(model.RefreshToken) )
            {
                return BadRequest("Invalid Token or RefreshToken Credentials.");
            }
            try
            {
                var result = await _authService.Refresh(model);
                response.TokenModel = result.TokenModel;
                response.StatusMessage = result.StatusMessage;
                response.StatusCode = result.StatusCode;
                if (result.StatusCode == 400)
                {
                    return BadRequest($"{result.StatusMessage}");
                }
                return StatusCode(response.StatusCode, response);
            }
            catch(Exception ex)
            {
                response.StatusCode = response.StatusCode;
                response.StatusMessage = response.StatusMessage;
                return StatusCode(response.StatusCode, new { StatusCode = response.StatusCode, StatusMessage = response.StatusMessage });

            }
          

           // return Ok(response);
        }

        [HttpPost]
        [Route("InsertData")]
        public async Task<IActionResult> InsertData(SampleDataTypes model)
        {
            var result = await _authService.InsertSampleData(model);

            switch (result.StatusCode)
            {

                case 200:
                    return Ok(result);
                case 400:
                    return BadRequest(result);
                case 500:
                     return StatusCode(result.StatusCode, new { StatusCode = result.StatusCode, StatusMessage = result.StatusMessage });
                   //throw new  InternelException( result.StatusMessage );
                default:
                    return StatusCode(result.StatusCode, result);
            }
        }

    }
}
