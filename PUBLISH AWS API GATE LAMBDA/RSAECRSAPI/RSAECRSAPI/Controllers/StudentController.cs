using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RSAECRSAPI.ECRSDAL.Models;
using System.Data;
using System.Security.AccessControl;

namespace RSAECRSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IOptions<AppConfigurations> _options;
        private readonly SqlHelpers _sqlHelpers;
        public StudentController(
            IOptions<AppConfigurations> options
            )
        {
            _options = options;
            _sqlHelpers = new SqlHelpers(_options.Value.RetailerConnectionString.ToString());
        }
        [HttpGet]
        [Route("StudentDetails")]
        public async Task<IActionResult> GetStudentsDetails()
        {

          
            var storedProcName = "GetStudents";


            List<Student> students = null;
            students = new List<Student>();


            // using multiple Rows:
            //var customerTable = await _sqlHelpers.GetMultipleRows(storedProcName, null);

            var studentTable = await _sqlHelpers.GetMultipleDataRows(storedProcName, null);



            students = (from DataRow dr in studentTable
                         select new Student
                         {
                             Id = Convert.ToInt32(dr["Id"]),
                             Name = dr["Name"].ToString(),
                             RoleNumber = dr["RoleNumber"].ToString(),
                             
                             Address = dr["Address"].ToString()
                         }).ToList();

            return Ok(students);
        }
        // [HttpGet("transaction/cancel/{site}/{customer}/{transaction}/{sharedkey}/{secretKey}")]
        //  public IActionResult CancelTransaction(string site, string customer, string transaction, string sharedkey, string secretKey)
        [HttpGet("transaction")]
        public IActionResult CancelTransaction(string site)
        {
            // Your logic here
            return Ok("Cancel transaction successfully......");
        }
    }
}
