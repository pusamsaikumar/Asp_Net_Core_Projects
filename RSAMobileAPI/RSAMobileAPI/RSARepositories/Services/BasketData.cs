namespace RSAMobileAPI.RSARepositories.Services
{
    

    public class BasketData
    {
        public int BasketDataId { get; set; }
        public string Retailer { get; set; }
        public int POSId { get; set; }
        public int StoreId { get; set; }
        public int OperatorId { get; set; }

        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }

        public TimeSpan TransactionTime { get; set; }
        public int TransactionTotalAmount { get; set; }
        public int TransactionTaxAmount { get; set; }
        public string TransactionTenderType { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsProcessed { get; set; }
        public Guid BasketGUID { get; set; }
        public int IsUPCSplitComplete { get; set; }
        public bool IsProcessedForMfg { get; set; }
        //    //public int CreatedUserID { get; set; }

        //    public bool IsProcessedForMfg { get; set; } 
        //   // public int BasketStatusID { get; set; }
        //   // public string EcomOrderNumber { get; set; }
        //   // public string CustomField2 { get; set; }
        //    //public string LoyaltyID { get; set; }
        //   // public bool ProcessedReward { get; set; }
        //    //public bool ProcessedIntelliCoupon { get; set; }
        //    //public bool SentToBW { get; set; }




    }



}
