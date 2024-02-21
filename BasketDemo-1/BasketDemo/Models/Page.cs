using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Page
    {
        public Page()
        {
            PageItems = new HashSet<PageItem>();
        }

        public int Pid { get; set; }
        public int? Cid { get; set; }
        public int? PageId { get; set; }
        public string? ImageFull { get; set; }
        public string? ImageThumb { get; set; }
        public string? ImageMid { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }

        public virtual Circular? CidNavigation { get; set; }
        public virtual ICollection<PageItem> PageItems { get; set; }
    }
}
