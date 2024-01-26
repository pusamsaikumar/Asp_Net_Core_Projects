using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IConfiguration _configuration ;
        public TodosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // get all todos
        [HttpGet]
        [Route("GetNotes")]
        public JsonResult GetNotes()
        {
            string query = "select * from notes";
            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SNCon");
            SqlDataReader myReader;
            using(SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query,connection)) {
                
                myReader = command.ExecuteReader();
                    dataTable.Load(myReader);
                    myReader.Close();
                    connection.Close();

                        
                        }
            }
            return new JsonResult(dataTable);
        }


        // addnewNotes
        [HttpPost]
        [Route("NewNotes")]

        public  JsonResult NewNotes([FromForm] string newNotes)
        {
            string query = "insert into notes values(@newNotes)";
            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SNCon");
            SqlDataReader myReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newNotes", newNotes);
                    myReader = command.ExecuteReader();
                    dataTable.Load(myReader);
                    myReader.Close();
                    connection.Close();


                }
            }
            return new JsonResult("Added successfully");
        }

        [HttpDelete]
        [Route("DeleteNotes")]
        public JsonResult DeleteNotes(int id)
        {
            string query = " delete from notes where id=@id";
            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SNCon");
            SqlDataReader myReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    myReader = command.ExecuteReader();
                    dataTable.Load(myReader);
                    myReader.Close();
                    connection.Close();


                }
            }
            return new JsonResult("Deleted successfully");
        }

    }






























}
