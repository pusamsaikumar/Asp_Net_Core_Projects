using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Roles = new HashSet<WebpagesRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;

        public virtual ICollection<WebpagesRole> Roles { get; set; }
    }
}
