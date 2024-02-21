using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Coupon
    {
        public int CouponId { get; set; }
        public Guid CouponUniqueId { get; set; }
        public string CouponCode { get; set; } = null!;
        public int UserDetailId { get; set; }
        public int NoDiscountProductId { get; set; }
        public int NoDiscountCount { get; set; }
        public int? UpSellProductId { get; set; }
        public int UpSellCount { get; set; }
        public decimal? DiscountPercentageCount { get; set; }
        public int CouponStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? RedeemOn { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public bool? IsDiscountaPercentage { get; set; }
        public string? PromotionId { get; set; }
        public string? NcrpromotionCode { get; set; }
        public DateTime? NcrpromotionCreatedDate { get; set; }
    }
}
