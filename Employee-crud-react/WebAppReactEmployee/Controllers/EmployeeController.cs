using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebAppReactEmployee.Models;

namespace WebAppReactEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // get all employees details
        [HttpGet]
        public JsonResult GetEmployee()
      
        {
              string query = "select EmployeeId,EmployeeName, Department,convert(varchar(10),DateOfJoining,120) as DateOfJoining, PhotoFileName from Employee";

           // string query = "select * from Employee";
            DataTable dataTable = new DataTable();
            string source = _configuration.GetConnectionString("SNCon");
            SqlDataReader reader;
             using(SqlConnection connection = new SqlConnection(source))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    dataTable.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }

             return new JsonResult(dataTable);

        }

        [HttpPost]
        public JsonResult PostEmployee(Employee employee)
        {
            string query = "insert into Employee(EmployeeName, Department, DateOfJoining, PhotoFileName) values('" + employee.EmployeeName + "','" + employee.Department + "','" + employee.DateOfJoining + "','" + employee.PhotoFileName + "') ";
            DataTable table = new DataTable();
            string Source = _configuration.GetConnectionString("SNCon");
            SqlDataReader reader;
            using( SqlConnection connection = new SqlConnection(Source))
            {
                connection.Open();
                using( SqlCommand command = new SqlCommand(query,connection))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();

                }
            }
            return new JsonResult("Added successfully");
        }
        [HttpPut]
        public JsonResult PutEmployee(Employee employee)
        {
            string query = "update Employee set EmployeeName = '" + employee.EmployeeName + "', Department='" + employee.Department + "', DateOfJoining='" + employee.DateOfJoining + "', PhotoFileName='" + employee.PhotoFileName + "' where EmployeeId='"+employee.EmployeeId+"' ";       
            DataTable Table = new DataTable();
            string Source = _configuration.GetConnectionString("SNCon");
            SqlDataReader reader;
            using(SqlConnection connection = new SqlConnection(Source)) {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                { reader = command.ExecuteReader(); 
                   Table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Updated successfully");
        }


        // DELETE:
        [HttpDelete("{id}")]
        public JsonResult DeleteEmployee(int id)
        {
            string query = "delete from Employee where EmployeeId='" + id + "'";
            DataTable Table = new DataTable();
            string source = _configuration.GetConnectionString("SNCon");
            SqlDataReader reader;
            using( SqlConnection connection = new SqlConnection(source))
            { connection.Open();
               using( SqlCommand command = new SqlCommand(query,connection))
                { reader = command.ExecuteReader(); 
                   Table.Load(reader) ;
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Deleted successfully");
        }

        //SAVE FILE PHOTO:
        [HttpPost]
        [Route("SaveFile")]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var PostedFile = httpRequest.Files[0];
                string filename = PostedFile.FileName;
                var PhysicalPath = _env.ContentRootPath +"/Photos/" + filename;
                using(var stream = new FileStream(PhysicalPath,FileMode.Create))
                {
                    PostedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            } catch(Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
    }
}
