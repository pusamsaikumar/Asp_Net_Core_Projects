using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication2social.Models;

namespace WebApplication2social.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NewsController(IConfiguration configuration) {
            _configuration = configuration;
        }

        // add news :
        [HttpPost]
        [Route("AddNews")]
        public Response AddNews(News news)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal da = new Dal();
            response = da.AddNews(news, connection);
            return response;
        }
        // get all news
        [HttpPost]
        [Route("NewsList")]
        public Response NewsList(News news)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal da = new Dal();
            response = da.NewsList(news, connection);
            return response;
        }
    }
}
