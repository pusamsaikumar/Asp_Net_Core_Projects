using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class BasketCoupon
    {
        public int BasketCouponId { get; set; }
        public int? BasketDataId { get; set; }
        public string? Id { get; set; }
        public string? IdType { get; set; }
        public string? Type { get; set; }
        public int? Value { get; set; }
        public string? Source { get; set; }
        public int? IncentiveId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
