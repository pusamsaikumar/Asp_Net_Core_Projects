namespace socialMedia.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Registration> listRegistration { get; set; }
        public List<Staff> staffs { get; set; }
        public Registration registration { get; set; }
        public List<Article> listArticle { get; set; }
        public List<News> listNews { get; set; }
        public List<Events> listEvents { get; set; }
        

    }
}
