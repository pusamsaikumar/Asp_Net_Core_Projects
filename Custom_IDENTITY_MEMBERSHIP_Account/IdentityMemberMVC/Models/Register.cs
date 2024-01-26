using System.ComponentModel.DataAnnotations;

namespace IdentityMemberMVC.Models
{
    public class Register
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Password don't Match.")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        [DataType(DataType.MultilineText )]
        public string? Address { get; set; }
    }
}
