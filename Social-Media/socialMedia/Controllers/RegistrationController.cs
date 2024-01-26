using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialMedia.Models;
using System.Data.SqlClient;

namespace socialMedia.Controllers
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

        // create Registration:
        [HttpPost]
        [Route("Registration")]
        public Response Registration(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.Registration(registration, connection );
            return response;
        }

        // login 

        [HttpPost]
        [Route("Login")]
        public Response Login(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.Login(registration, connection);
            return response;
        }

        // update the user approval
        [HttpPut]
        [Route("UserApproval")]
        public Response UserApproval(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.UserApproval(registration, connection);
            return response;
        }

        // staff registration:
        [HttpPost]
        [Route("StaffRegistration")]
        public Response StaffRegistration(Staff staff)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.StaffRegistration(staff, connection);
            return response;
        }

        [HttpDelete]
        [Route("DeleteStaff")]
        public Response DeleteStaff(Staff staff)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.DeleteStaff(staff, connection);
            return response;
        }

        // get user registration list
        [HttpPost]
        [Route("RegistrationList")]
        public Response RegistrationList(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.RegistrationList(registration, connection);
            return response;
        }

        // get user registration list
        [HttpPost]
        [Route("StaffRegistrationList")]
        public Response StaffRegistrationList(Staff staff)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.StaffRegistrationList(staff, connection);
            return response;
        }
    }
}
