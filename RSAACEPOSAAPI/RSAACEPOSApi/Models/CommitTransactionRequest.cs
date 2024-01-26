namespace RSAACEPOSApi.Models
{
    public class CommitTransactionRequest
    {
        public string sharedKey { get; set; }
        public string secret { get; set; }
        public string customer { get; set; }
        public int site { get; set; }
        public string transaction { get; set; }
        public int cashier { get; set; }
        public int terminal { get; set; }
        public string time { get; set; }
        public List<string> coupons { get; set; }
         public List<Tender> tenders { get; set; }
    }
}
