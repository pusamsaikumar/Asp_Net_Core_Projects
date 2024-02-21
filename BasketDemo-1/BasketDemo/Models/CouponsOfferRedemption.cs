using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class CouponsOfferRedemption
    {
        public int CouponOfferRedemptionsId { get; set; }
        public string? OfferGuid { get; set; }
        public int? CouponOfferId { get; set; }
        public string? MemberNumber { get; set; }
        public int? RedemptionDistributionId { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? SentTime { get; set; }
        public bool? SentStatus { get; set; }
        public string? ErrorCode { get; set; }
        public int? ClearingStatusId { get; set; }
        public int? ClearingRecordId { get; set; }
    }
}
