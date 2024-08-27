using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTRoleAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }
       [Authorize(Roles ="User")]
        [HttpGet]
        [Route("GetUserDetails")]
        public IActionResult GetUserDetails()
        {
            return Ok(new
            {
                UserName = "saikumarpusam302@gmail.com",
                Email = "saikumarpusam302@gmail.com",
                DateOfBirth = "09-11-1994",
                MobileNumber = "9959608677",
                Role = "User"
            });
        }
    }
}
