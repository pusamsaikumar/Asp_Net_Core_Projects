using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmRewardUpdateQueue
    {
        public int RewardUpdateQueueId { get; set; }
        public int? RewardId { get; set; }
        public bool? IsProcessed { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
