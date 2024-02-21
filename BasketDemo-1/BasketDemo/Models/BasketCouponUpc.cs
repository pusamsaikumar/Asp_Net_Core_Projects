using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class BasketCouponUpc
    {
        public int BasketCouponUpcid { get; set; }
        public int? BasketCouponId { get; set; }
        public string? BasketCouponPromotionId { get; set; }
        public int? BasketDataId { get; set; }
        public string? Upc { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
