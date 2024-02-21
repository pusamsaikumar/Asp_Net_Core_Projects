using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class AspnetUser
    {
        public AspnetUser()
        {
            AspnetPersonalizationPerUsers = new HashSet<AspnetPersonalizationPerUser>();
        }

        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string LoweredUserName { get; set; } = null!;
        public string? MobileAlias { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime LastActivityDate { get; set; }

        public virtual AspnetApplication Application { get; set; } = null!;
        public virtual AspnetMembership AspnetMembership { get; set; } = null!;
        public virtual AspnetProfile AspnetProfile { get; set; } = null!;
        public virtual AspnetUsersInRole AspnetUsersInRole { get; set; } = null!;
        public virtual ICollection<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }
    }
}
