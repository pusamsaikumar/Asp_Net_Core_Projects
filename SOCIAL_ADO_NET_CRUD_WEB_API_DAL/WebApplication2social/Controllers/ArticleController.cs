using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication2social.Models;

namespace WebApplication2social.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ArticleController(IConfiguration configuration) {
            _configuration = configuration;
        }
        // add articel
        [HttpPost]
        [Route("AddArticle")]
        public Response AddArticle(Article article )
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.AddArticle(article, connection);
            return response;
        }

        // get all articles
        [HttpGet]
        [Route("ArticleList")]
        public Response ArticleList(Article article)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ArticleList(article, connection);
            return response;
        }

        // Article approval:
        [HttpPost]
        [Route("ArticleApproval")]
        public Response ArticleApproval(Article article)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.AtricleApproval(article, connection);
            return response;
        }
    }
}
