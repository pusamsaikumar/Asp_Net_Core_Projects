namespace socialMedia.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
     
        public int IsActive { get; set; }
     public string? UserType { get; set; }
    }
}
