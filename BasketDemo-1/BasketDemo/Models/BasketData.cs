namespace BasketDemo.Models
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

        public DateTime TransactionTime { get; set; }
        public int TransactionTotalAmount { get; set; }
        public int TransactionTaxAmount { get; set; }
        public string TransactionTenderType { get; set; }

        public DateTime CreatedDate { get; set; }



    }

}
