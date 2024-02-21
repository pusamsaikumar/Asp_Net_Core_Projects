using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class NewsTarget
    {
        public int NewsTargetId { get; set; }
        public int? NewsId { get; set; }
        public int? ClubId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsExclude { get; set; }

        public virtual Club? Club { get; set; }
        public virtual Ssnews? News { get; set; }
    }
}
