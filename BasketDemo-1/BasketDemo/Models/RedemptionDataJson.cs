using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class RedemptionDataJson
    {
        public int RedeemOfferJsonId { get; set; }
        public int? Id { get; set; }
        public int? ErrorCode { get; set; }
        public string? CouponOfferGuid { get; set; }
        public string? RedemptionJson { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
