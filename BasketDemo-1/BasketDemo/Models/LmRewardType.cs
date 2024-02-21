using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmRewardType
    {
        public int Id { get; set; }
        public int RewardType { get; set; }
        public string Description { get; set; } = null!;
        public string? ExcludeDepartmentList { get; set; }
    }
}
