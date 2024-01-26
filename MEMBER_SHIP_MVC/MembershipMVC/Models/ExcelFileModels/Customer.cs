using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace MembershipMVC.Models.ExcelFileModels
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }    = string.Empty;
        public string Job { get; set; } = string.Empty;
        public float Amount { get; set; }
        public DateTime Tdate { get; set; } 
    }
}
