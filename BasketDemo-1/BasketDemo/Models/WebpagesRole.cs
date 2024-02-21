using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class WebpagesRole
    {
        public WebpagesRole()
        {
            Users = new HashSet<UserProfile>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<UserProfile> Users { get; set; }
    }
}
