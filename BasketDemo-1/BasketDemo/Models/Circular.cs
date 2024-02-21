using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Circular
    {
        public Circular()
        {
            Groups = new HashSet<Group>();
            Pages = new HashSet<Page>();
        }

        public int Cid { get; set; }
        public long? CircularId { get; set; }
        public string? CircularName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsProcessed { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
