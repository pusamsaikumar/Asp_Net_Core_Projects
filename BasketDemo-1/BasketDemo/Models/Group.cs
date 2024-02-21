using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupPages = new HashSet<GroupPage>();
        }

        public int Gid { get; set; }
        public int? Cid { get; set; }
        public int? GroupId { get; set; }
        public string? GroupName { get; set; }
        public long? ActiveDateNum { get; set; }
        public long? TerminationDateNum { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? ActiveDate { get; set; }

        public virtual Circular? CidNavigation { get; set; }
        public virtual ICollection<GroupPage> GroupPages { get; set; }
    }
}
