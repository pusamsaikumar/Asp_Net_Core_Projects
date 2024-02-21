using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class DistributorCouponsUpdateQueue
    {
        public int DistCouponUpdateQueueId { get; set; }
        public string? OfferIdGuid { get; set; }
        public int? VersionId { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public bool? Isprocessed { get; set; }
        public int? DistCouponsOfferId { get; set; }
    }
}
