using Microsoft.OpenApi.Writers;

namespace WebApplication2social.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }   
        public List<Registration> listRegistration { get; set; }
        public Registration Registration  { get; set; }
        public List<Article> listArticles { get; set; }
        public List<News> listNews { get; set; }
        public List<Events> listEvents { get; set; }
    }
}
