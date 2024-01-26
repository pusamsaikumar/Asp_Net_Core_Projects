namespace WebApplication1sai.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string SatusMessage { get; set; }
        public List<Registration>ListReg{ get; set; }
        public Registration Registration { get; set; }
    }
}
