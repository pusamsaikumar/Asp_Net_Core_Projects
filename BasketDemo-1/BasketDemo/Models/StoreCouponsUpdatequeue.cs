using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class StoreCouponsUpdatequeue
    {
        public int StoreCouponUpdateQueueId { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public bool? Isprocessed { get; set; }
        public int? OfferId { get; set; }
    }
}
