using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmRewardTarget
    {
        public int LmrewardTargetId { get; set; }
        public int? LmrewardId { get; set; }
        public int? ClubId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsExclude { get; set; }

        public virtual Club? Club { get; set; }
        public virtual LmReward? Lmreward { get; set; }
    }
}
