using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmRewardGroup
    {
        public int LmRewardGroupId { get; set; }
        public int? LmrewardId { get; set; }
        public int? RewardGroupId { get; set; }
        public int? CouponId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
