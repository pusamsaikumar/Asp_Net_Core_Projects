namespace RSAECRSAPI.ECRSDAL.Models
{
    public class AppConfigurations  
    {
        public string SharedKey { get; set; }
        public string SecretKey { get; set; }
        public string RetailerName { get; set; }
        public string RemoveCheckDigitFromBasketUPC { get; set; }
        public string MemberNumberLength { get; set; }
        public string MaxCouponValueForClient { get; set; }
        public string RSACoreAPIUrl { get; set; }
        public string SystemNotificationsARN { get; set; }
        public string EnableRemoveNCRImpression { get; set; }
        public string EnterpriseId { get; set; }
        public string EnterpriseSecret { get; set; }
        public string NCRImpressionAPIUrl { get; set; }
        public string UPCCouponTypeIds { get; set; }
        public string CrossSellCouponTypeIds { get; set; }
        public string MFRUPCCouponTypeIds { get; set; }
        public string SetCouponMultiLineIdsToZero { get; set; }
        public string CrossSellCouponsPurchaseUPCsOrderByAmount { get; set; }
        public string EnableWriteLogs { get; set; }
        public string EnableEmailNotificationAlerts { get; set; }
        public string SendTransactionsToCloud { get; set; }
        public string POSType { get; set; }
        public string DBInstanceName { get; set; }
        public string DBName { get; set; }
        public string CloudRetailerName { get; set; }
        public string RetailerTimeZone { get; set; }
        public string SendTransactionToCloudURL { get; set; }
        public string SendCommitToCloudURL { get; set; }
        public string GetTransactionCloudURL { get; set; }
        public string MoveTransactionToProcessedFolderCloudURL { get; set; }
        public string RetailerConnectionString { get; set; }
        public string SqlCommandTimeout { get; set; }
        public string ApplyOnlyOneBasketCouponFlag { get; set; }
        public string SaveRealtimeTransactionData { get; set; }
    }
}
