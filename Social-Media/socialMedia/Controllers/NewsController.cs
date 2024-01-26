using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialMedia.Models;
using System.Data.SqlClient;

namespace socialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NewsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // CREATE NEWS:
        [HttpPost]
        [Route("createNews")]
        public Response News(News news)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.News(news, connection);
            return response;
        }

        // get active list of news:
        [HttpGet]
        [Route("getNewsList")]
        public Response ListNews()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ListNews(connection);
            return response;
        }
    }
    }
