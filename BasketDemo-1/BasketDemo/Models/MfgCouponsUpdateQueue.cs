using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class MfgCouponsUpdateQueue
    {
        public int MfgcouponUpdateQueueId { get; set; }
        public string? OfferIdGuid { get; set; }
        public int? VersionId { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public bool? Isprocessed { get; set; }
        public int? OfferId { get; set; }
    }
}
