namespace RSAMobileAPI.RSADALayer
{
    public class LM_GetBasketRewardForMobileApi_Result
    {
        public int LMRewardId { get; set; }
        public string Title { get; set; }
        public string RewardTitle { get; set; }
        public string RewardDetails { get; set; }
        public int RewardTypeId { get; set; }
        public string RewardImageURL { get; set; }
        public int? BuyQtyAmount { get; set; }
        public int? PurchasedQty { get; set; }
        public decimal? PurchasedAmount { get; set; }
        public decimal? RedeemAmount { get; set; }
    }
}
