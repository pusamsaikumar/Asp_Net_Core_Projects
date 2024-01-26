namespace socialMedia.Models
{
    public class Events
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }

        public int IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
