using System.ComponentModel.DataAnnotations;

namespace MembershipMVC.Models
{
    public class ForgotModelView
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
