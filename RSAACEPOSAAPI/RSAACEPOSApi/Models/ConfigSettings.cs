namespace RSAACEPOSApi.Models
{
    public class ConfigSettings
    {
        public string ConfigFileName { get; set; }

        public string RetailerId { get; set; }
        public string RetailerName { get; set; }
        public string RemoveCheckDigitFromBasketUPC { get; set; }

        public string SharedKey { get; set; }

        public string SecretKey { get; set; }

        public string MemberNumberLength { get; set; }

        public string ClientBucketName { get; set; }

        public string ProcessCoupons { get; set; }

        public string ProcessPromotions { get; set; }

        public string EnablePromotionsForMembersOnly { get; set; }

        public string EnablePromotionsForAll { get; set; }

        public string CostPlusStoreIds { get; set; }

        public string MaxCouponValueForClient { get; set; }

        public string PromotionsAPIUrl { get; set; }

        public string RSACoreAPIUrl { get; set; }

        public string SystemNotificationsARN { get; set; }

        public string EnableRemoveNCRImpression { get; set; }

        public string EnterpriseId { get; set; }
        public string EnterpriseSecret { get; set; }

        public string BaseUrl { get; set; }

        public string UPCCouponTypeIds { get; set; }

        public string MFRUPCCouponTypeIds { get; set; }

        public string SetCouponMultiLineIdsToZero { get; set; }

        public string CrossCellCouponsPurchaseUPCsOrderByAmount { get; set; }

        public string EnableWriteLogs { get; set; }

        public string EnableEmailNotificationAlerts { get; set; }

        public string MustBuyPromotionTitle { get; set; }

        public string GroupDiscountPromotionOverrideType { get; set; }

       

     
    }
   public class ConfigsValues
    {
        public List<ConfigSettings> ConfigSettings { get; set; }    
    }
}
