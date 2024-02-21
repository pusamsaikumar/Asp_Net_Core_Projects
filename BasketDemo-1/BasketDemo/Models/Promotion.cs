using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Promotion
    {
        public int Id { get; set; }
        public string? PromotionId { get; set; }
        public decimal? DiscountPercentageCount { get; set; }
        public bool? IsDiscountaPercentage { get; set; }
        public int? NoDiscountProductId { get; set; }
        public int? NoDiscountCount { get; set; }
        public int? UpSellProductId { get; set; }
        public int? UpSellCount { get; set; }
        public bool? IsPromotionTarget { get; set; }
        public string? NcrpromotionCode { get; set; }
        public DateTime? NcrpromotionCreatedDate { get; set; }
    }
}
