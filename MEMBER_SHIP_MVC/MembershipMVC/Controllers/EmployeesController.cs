using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MembershipMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize]
    public class EmployeesController : ControllerBase
    {

       // [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] {"sai","vijay","vinay" });
        }
    }
}
