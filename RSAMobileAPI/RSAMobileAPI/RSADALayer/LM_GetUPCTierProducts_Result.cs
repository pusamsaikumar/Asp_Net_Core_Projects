namespace RSAMobileAPI.RSADALayer
{
    public class LM_GetUPCTierProducts_Result
    {
        public int LMRewardTierID {  get; set; }  
        public int LMRewardID { get; set; }
        public string TierTitle { get; set; } 
        public int? PointsRequired { get; set; }
        public decimal? CouponValue { get; set; }
        public int? TierRewardCouponTypeId { get; set; }
        public bool? IsItQualifiedforReward { get; set; }
        public bool? IsDiscountPercentage { get; set; }
        public string Title { get; set; }   
        public string UPC {  get; set; }    
        public string ProductName { get; set; } 
        public string DeductPointsText { get; set; }
        public string ImageUrl { get; set; }    
    }
}









