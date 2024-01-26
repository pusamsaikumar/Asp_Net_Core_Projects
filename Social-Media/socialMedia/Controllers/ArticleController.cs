using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialMedia.Models;
using System.Data.SqlClient;

namespace socialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ArticleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // add articles:
        [HttpPost]
        [Route("AddArticle")]
        public Response AddArticle(Article article)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.AddArticle(article, connection);

            return response;
        }

        [HttpGet]
        [Route("ArticleList")]
        public Response ArticleList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ArticleList( connection);

            return response;
        }

        [HttpPost]
        [Route("ArticleListUser")]
        public Response ArticleListUser(Article article)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ArticleListUser(article, connection);

            return response;
        }

        [HttpPut]
        [Route("ArticleApproval")]
        public Response ArticleApproval(Article article)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ArticleApproval(article, connection);

            return response;
        }
    }
}
