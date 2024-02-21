using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Redemption
    {
        public string? RedemptionId { get; set; }
        public string? Category { get; set; }
        public int? UserId { get; set; }
        public DateTime? RedemptionDate { get; set; }
        public int? UserStoreId { get; set; }
        public int? RedeemCount { get; set; }
        public decimal? RedeemAmount { get; set; }
        public decimal? SaleAmount { get; set; }
        public string? Title { get; set; }
        public decimal? CostAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? PromotionId { get; set; }
        public int? BasketId { get; set; }
        public string? TransactionDate { get; set; }
        public string? TransactionTime { get; set; }
        public string? Upc { get; set; }
        public int? NewsCategoryId { get; set; }
    }
}
