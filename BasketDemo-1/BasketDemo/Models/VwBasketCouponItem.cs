using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class VwBasketCouponItem
    {
        public string? ItemUpc { get; set; }
        public string? BasktcouponUpc { get; set; }
        public int BasketItemId { get; set; }
        public int? BasketDataId { get; set; }
        public string? BasketCouponPromotionId { get; set; }
        public int? NewsCategoryId { get; set; }
        public int NewsId { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? BasketCouponId { get; set; }
        public int? Qty { get; set; }
    }
}
