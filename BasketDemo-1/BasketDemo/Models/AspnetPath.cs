using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class AspnetPath
    {
        public AspnetPath()
        {
            AspnetPersonalizationPerUsers = new HashSet<AspnetPersonalizationPerUser>();
        }

        public Guid ApplicationId { get; set; }
        public Guid PathId { get; set; }
        public string Path { get; set; } = null!;
        public string LoweredPath { get; set; } = null!;

        public virtual AspnetApplication Application { get; set; } = null!;
        public virtual AspnetPersonalizationAllUser AspnetPersonalizationAllUser { get; set; } = null!;
        public virtual ICollection<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }
    }
}
