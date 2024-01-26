using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebAppReactEmployee.Models;

namespace WebAppReactEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // get departments:
        [HttpGet]
        public JsonResult Getdept()
        {
            string query = "select * from Department";
            //string query = "select DepartmentId, DepartmentName from Department";

            DataTable dataTable = new DataTable();
            string SqlDataSouce = _configuration.GetConnectionString("SNCon");
            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(SqlDataSouce))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    reader = cmd.ExecuteReader();
                    dataTable.Load(reader);
                    reader.Close();
                    conn.Close();
                }
            }

            return new JsonResult(dataTable);

        }

        // create departments:
        [HttpPost]
        public JsonResult CreateDept(Department department)
        {
            string query = "insert into Department(DepartmentName) values('" + department.DepartmentName + "')";
            DataTable dataTable = new DataTable();
            string source = _configuration.GetConnectionString("SNCon");
            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(source))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    reader = cmd.ExecuteReader();
                    dataTable.Load(reader);
                    reader.Close();
                    conn.Close();

                }

            }

            return new JsonResult("Added Successfully");

        }
        //updated
        [HttpPut]
        public JsonResult UpdateDept(Department department)
        {
            string query = "update Department set DepartmentName = '" + department.DepartmentName + "' where DepartmentId = '" + department.DepartmentId + "' ";
            DataTable dataTable = new DataTable();
            string source = _configuration.GetConnectionString("SNCon");
            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(source))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    reader = cmd.ExecuteReader();
                    dataTable.Load(reader);
                    reader.Close();
                    conn.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        // deleted
        [HttpDelete("{id}")]
        public JsonResult DeleteDepartment(int id)

        {
            // string query = "delete from Department where DepartmentId=@DepartmentId ";
            string query = "delete from Department where DepartmentId='" + id + "' ";

            DataTable dataTable = new DataTable();
            string source = _configuration.GetConnectionString("SNCon");
            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(source))
            {
                conn.



                        Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    reader = cmd.ExecuteReader();
                    //  cmd.Parameters.AddWithValue("@DepartmentId", id);
                    dataTable.Load(reader);
                    reader.Close();
                    conn.Close();

                }
            }
            return new JsonResult("Deleted Successfully");
        }

    }

}