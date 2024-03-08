namespace RSAMobileAPI.RSADALayer
{
    public class LM_GetAllRewardsForDepartment_Result
    {
        public int LMRewardId { get; set; } 
        public string Title { get; set; }   
        public string RewardTitle { get; set; }
        public string POSDetails { get; set;}
        public string AdditionalDetails { get; set; }   
        public int RewardTypeId { get; set; }   
        public string RewardTypeName { get; set;}
        public int? BuyQtyAmount { get; set; }
        public string productUpcs { get; set; } 
        public int? PurchasedQty {  get; set; }  
        public decimal? PurchasedAmount { get;}
    }
}









