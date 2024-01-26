using System.ComponentModel.DataAnnotations;

namespace IdentityMemberMVC.Models
{
    public class Login
    {
       [Required(ErrorMessage = "Username is required.")]
      
        public string? Username { get; set; } 
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        //public string ReturnUrl { get; internal set; }
    }
}

