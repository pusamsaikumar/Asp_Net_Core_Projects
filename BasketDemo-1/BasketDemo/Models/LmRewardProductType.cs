using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmRewardProductType
    {
        public int RewardProductTypeId { get; set; }
        public string RewardProductType { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
