using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication1sai.Models;

namespace WebApplication1sai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Registration")]
        public Response Registration(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal da = new Dal();
            response = da.Registration(registration, connection);
                
            return response;

        }

        [HttpGet]
        [Route("RegistrationList")]
        public Response RegistrationList(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal da = new Dal();
            response = da.RegistrationList(registration, connection);
            return response;
        }


    }
}
