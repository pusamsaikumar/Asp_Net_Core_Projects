using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SsnewsRecurring
    {
        public long RecurringId { get; set; }
        public int? NewsId { get; set; }
        public DateTime? RecurringStartDate { get; set; }
        public DateTime? RecurringEndDate { get; set; }
        public int? RecurringTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Ssnews? News { get; set; }
    }
}
