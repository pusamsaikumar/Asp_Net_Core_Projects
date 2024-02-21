using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class MfgCouponsHold
    {
        public int MfgCouponHoldId { get; set; }
        public int CouponOfferId { get; set; }
        public int? SsnewsId { get; set; }
        public bool? HoldOfferRedemptions { get; set; }
        public bool? HoldOfferToShopper { get; set; }
        public int? HoldStatus { get; set; }
        public bool? IsHoldStoreLevel { get; set; }
        public string ManufacturerId { get; set; } = null!;
        public string ManucaturerCode { get; set; } = null!;
        public int? NchclearingHouseId { get; set; }
        public string? Comments { get; set; }
        public string? ResolutionComments { get; set; }
        public int? ResolvedByUserId { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? HoldDate { get; set; }
    }
}
