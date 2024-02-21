using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class GroupPage
    {
        public int Id { get; set; }
        public int Gid { get; set; }
        public int? SortNum { get; set; }
        public long? PageId { get; set; }

        public virtual Group GidNavigation { get; set; } = null!;
    }
}
