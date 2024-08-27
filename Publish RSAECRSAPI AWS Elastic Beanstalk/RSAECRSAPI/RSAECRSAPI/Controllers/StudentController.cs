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
        // [HttpGet("transaction/cancel/{site}/{customer}/{transaction}/{sharedkey}/{secretKey}")]
        //  public IActionResult CancelTransaction(string site, string customer, string transaction, string sharedkey, string secretKey)
        [HttpGet("transaction")]
        public IActionResult CancelTransaction(string site)
        {
            // Your logic here
            return Ok();
        }
    }
}
