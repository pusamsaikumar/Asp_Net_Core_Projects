using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MembershipMVC.Models
{
    public class Edit
    {
        
        public string Id { get; set; }
       // [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
       // [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
       // [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string? Email { get; set; }
     //   [Required]
       // [DataType(DataType.Password)]
       public string? Password { get; set; }
        //[Compare("Password", ErrorMessage = "Password don't Match.")]
        //[Display(Name = "ConfirmPassword")]
        //[DataType(DataType.Password)]
        //public string? ConfirmPassword { get; set; }
        // [DataType(DataType.Text)]
     //   [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
       
    }
}
