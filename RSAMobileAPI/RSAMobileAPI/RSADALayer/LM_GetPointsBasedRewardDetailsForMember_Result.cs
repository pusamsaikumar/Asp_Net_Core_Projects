namespace RSAMobileAPI.RSADALayer
{
    public class LM_GetPointsBasedRewardDetailsForMember_Result
    {
        public int LMRewardTierID { get; set; } 
        public int LMRewardID { get; set; } 
        public string TierTitle { get; set; }   
        public string RewardImageURL { get; set;}
        public int RewardTypeId { get; set; }
        public int? PointsRequired { get; set; }
        public decimal? CouponValue { get; set; }
        public decimal? MinRequiredAmount { get; set; }
        public int? TierRewardCouponTypeId { get; set; }
        public string TierImageUrl {  get; set; }   
        public bool? IsDiscountPercentage { get; set; }
        public decimal? MemberPoints {  get; set; } 
        public string Title { get; set; }
        public string RewardTitle { get; set; } 
        public string RewardDetails { get; set; }   
        public string RewardAdditionalDetails { get; set; } 
        public string RewardPointsText { get; set; }
        public string RewardOptionsText { get; set; }   
        public string RewardAdditionalTermsText { get; set; }   
        public string RewardDetailsNoteText { get; set; } 
        public string TierTitleDesc { get; set; }   

    }
}



