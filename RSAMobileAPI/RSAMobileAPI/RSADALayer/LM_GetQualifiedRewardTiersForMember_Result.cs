namespace RSAMobileAPI.RSADALayer
{
    public class LM_GetQualifiedRewardTiersForMember_Result
    {
        public int LMRewardTierID { get; set; }
        public int LMrewardID { get; set; }
        public string TierTitle { get; set; }
        public int? PointsRequired { get; set; }
        public decimal? CouponValue { get; set; }
        public int? CurrentPoints { get; set; }
    }
}



