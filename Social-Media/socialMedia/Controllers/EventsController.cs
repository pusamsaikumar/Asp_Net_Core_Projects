using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialMedia.Models;
using System.Data.SqlClient;

namespace socialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EventsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // add events

        [HttpPost]
        [Route("AddEvents")]
        public Response AddEvents(Events events)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.AddEvents(events, connection);

            return response;

        }

        // get all events 

        [HttpGet]
        [Route("Eventlist")]
        public Response Eventlist()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.Eventlist(connection);

            return response;

        }
    }
}
