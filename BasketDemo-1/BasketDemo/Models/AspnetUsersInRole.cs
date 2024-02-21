using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class AspnetUsersInRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual AspnetRole Role { get; set; } = null!;
        public virtual AspnetUser User { get; set; } = null!;
    }
}
