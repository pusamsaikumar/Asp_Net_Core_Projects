using System.ComponentModel.DataAnnotations;

namespace MembershipMVC.Models
{
    public class LoginViewModel
    {
        public string? Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
    }

}
