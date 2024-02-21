using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class AspnetRole
    {
        public AspnetRole()
        {
            AspnetUsersInRoles = new HashSet<AspnetUsersInRole>();
        }

        public Guid ApplicationId { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public string LoweredRoleName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual AspnetApplication Application { get; set; } = null!;
        public virtual ICollection<AspnetUsersInRole> AspnetUsersInRoles { get; set; }
    }
}
