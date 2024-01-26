using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApplication2social.Models;

namespace WebApplication2social.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase

    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // CREATE POST:
        [HttpPost]
        [Route("Registration")]
        public Response Registration(Registration registration)
        {
            Response response = new Response();

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            Dal dal = new Dal();
            response = dal.Registration(registration, connection);

            return response;
        }

        // login post
        [HttpPost]
        [Route("Login")]
        public Response Login(Registration registration) { 
               Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal da = new Dal();
            response = da.Login(registration, connection);
            return response;
        }

        // user approved
        [HttpPost]
        [Route("UserApproval")]
        public Response UserApproval(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal da = new Dal();
            response = da.UserApproval(registration, connection);
            return response;    
        }

        // staff registration:
        [HttpPost]
        [Route("StaffRegistration")]
        public Response StaffRegistration(Staff staff)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal da = new Dal();
            response= da.StaffRegistration(staff, connection);  
            return response;
        }

        // delete staff
        [HttpPost]
        [Route("DeleteStaff")]
        public Response DeleteStaff(Staff staff)
        {
            Response response= new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal da = new Dal();
            response = da.DeleteStaff(staff, connection);
            return response;
        }

        // Add Events:
        public Response AddEvents(Events events, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Events(Title,Content,Email,IsActive,CreatedOn) VALUES('"+events.Title+"','"+events.Content+"','"+events.Email+"',1,GETDATE())",connection);
    connection.Open();
        int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = " Events Created successfully";
            } else
            {
                response.StatusCode = 100;
                response.StatusMessage = " Events Creation failed";
            }
            return response;
        }

        // events list
        public Response EventsList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Events WHERE IsActive =1 ",connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Events> listEvents = new List<Events>();
            if (dt.Rows.Count > 0)
            {
                    for(int i=0; i<dt.Rows.Count; i++)
                {
                    Events event_ = new Events();
                    event_.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    event_.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    event_.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    event_.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    event_.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    event_.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    listEvents.Add(event_);

                }
                    if(listEvents.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Events data found";
                    response.listEvents = listEvents;
                } else
                {

                    response.StatusCode = 100;
                    response.StatusMessage = "No Events data found";
                    response.listEvents = null;
                }
            }else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Events data found";
                response.listEvents = null;
            }
            return response;
        }
    }
}