using Microsoft.AspNetCore.Authentication;
using Microsoft.SqlServer.Server;

namespace socialMedia.Models
{
    public class Registration
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNo { get; set; }
        public int IsActive { get; set; }
        public int IsApproved { get; set; }
        public  string? UserType { get; set; }

    }
}
