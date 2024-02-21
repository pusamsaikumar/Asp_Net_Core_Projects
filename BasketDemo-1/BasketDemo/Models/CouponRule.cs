using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class CouponRule
    {
        public int CouponRuleId { get; set; }
        public int ProductId { get; set; }
        public int PreviousConsumptionCount { get; set; }
        public int UpSellCount { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public int? NoDiscountProductId { get; set; }
        public int? NoDiscountCount { get; set; }
        public int? UpSellProductId { get; set; }
        public bool? IsDiscountaPercentage { get; set; }
    }
}
