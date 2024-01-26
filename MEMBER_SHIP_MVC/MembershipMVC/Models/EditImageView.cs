namespace MembershipMVC.Models
{
    public class EditImageView
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; } 
        public string? URL { get; set; }
    }
}
