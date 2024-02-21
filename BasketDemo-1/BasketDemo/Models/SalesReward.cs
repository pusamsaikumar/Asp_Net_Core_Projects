using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SalesReward
    {
        public int RewardNo { get; set; }
        public int? RedeemSno { get; set; }
        public string? OfferItemType { get; set; }
        public string? RedeemId { get; set; }
        public string? Name { get; set; }
        public string? Reference { get; set; }
        public int? UnitCount { get; set; }
        public string? UnitPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
