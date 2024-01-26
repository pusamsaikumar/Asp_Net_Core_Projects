using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityMemberMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        // public string? FirstName { get; set; }
        // public string? LastName { get; set; }

        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }
        public string? Address { get; set; }
        
    }
}
