using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTRoleAuthentication.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController()
        {
            
        }
        [Authorize(Roles= "User")]
        [HttpGet]
        [Route("GetStudentNames")]
        public IActionResult GetStudentNames()
        {
          return  Ok(new object[] { "Vinay","Vijay","Sai" });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("Hello Admin!");
        }

        [Authorize(Roles = "User")]
        [HttpGet("user")]
        public IActionResult UserEndpoint()
        {
            return Ok("Hello User!");
        }

    }
}
