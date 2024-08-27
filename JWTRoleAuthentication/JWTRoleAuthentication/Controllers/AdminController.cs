using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTRoleAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController()
        {

        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        [Route("GetContactInfo")]
        public IActionResult GetContactInfo()
        {
            return Ok(new
            {
                Name = "Sai Kumar",

                Mobile = "9959608677",
                Address = "Hyderabad, Manikonda, Marrichettu junction."
            });
        }
    }
}
