using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmReward
    {
        public LmReward()
        {
            LmRewardTargets = new HashSet<LmRewardTarget>();
        }

        public int LmRewardId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Title { get; set; } = null!;
        public int RewardTypeId { get; set; }
        public int? BuyQtyAmount { get; set; }
        public int? RewardQtyAmount { get; set; }
        public string RewardTitle { get; set; } = null!;
        public string AdditionalDetails { get; set; } = null!;
        public string Posdetails { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? RewardGroupId { get; set; }
        public int? CouponId { get; set; }
        public int? IsStoreSpecific { get; set; }
        public int? RewardStatus { get; set; }
        public int? RewardDepartmentId { get; set; }
        public DateTime? RewardMustBeUsedByDate { get; set; }
        public bool? IsTargetSpecific { get; set; }
        public bool? IsDiscountPercentage { get; set; }
        public int? RewardCouponMinQty { get; set; }
        public int? RewardCouponTypeId { get; set; }
        public decimal? RewardQtyAmountMoney { get; set; }

        public virtual ICollection<LmRewardTarget> LmRewardTargets { get; set; }
    }
}
