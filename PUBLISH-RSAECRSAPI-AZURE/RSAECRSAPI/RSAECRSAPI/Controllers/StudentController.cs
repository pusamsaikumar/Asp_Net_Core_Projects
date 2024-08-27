using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RSAECRSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController()
        {
            
        }
        [HttpGet]
        [Route("StudentName")]
        public async Task<IActionResult> GetStudentsNames()
        {
            return Ok(new[] { "saikuamr", "vijay kumar", "vinay kumar" });
        }
    }
}
