using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LoginDemo.Models
{
    public class RewardsModel
    {
        [Display(Name = "Member Number")]
        public string FindMember { get; set; }
        [Display(Name = "Enter CouponId")]
        public string CouponId { get; set; }
        public int RewardId { get; set; }
        public string RewardCheck { get; set; }
        public string Title { get; set; }
        public IEnumerable<SelectListItem> DDLRewards { get; set; }
    }
    public class LoyalityMember
    {
        [Key]
        public int id { get; set; }     
        public string LoyalityID { get; set; }  
    }
    public class LMGetReward
    {
        [Key]
        [JsonProperty("RewardID")]
        public int RewardId { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Buy Qty Amount")]
        public string BuyQtyAmount { get; set; }
        [JsonProperty("Purchased Qty")]
        public string PurchasedQty { get; set; }
        [JsonProperty("Purchased Amount")]
        public string PurchasedAmount { get; set; }
    }
    public class LoyaltyRewards
    {
        [JsonProperty("RewardID")]
        public long RewardId { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }


    }


    public class RewardsList
    {
        [JsonProperty("LoyaltyRewards")]
        public List<LoyaltyRewards> GetRewardsList { get; set; }
    }

}
