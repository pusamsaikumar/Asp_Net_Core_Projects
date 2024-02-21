using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmRewardProduct
    {
        public int LmRewardProductId { get; set; }
        public int LmRewardId { get; set; }
        public int ProductId { get; set; }
        public string Upc { get; set; } = null!;
        public int? RewardProductTypeId { get; set; }
    }
}
