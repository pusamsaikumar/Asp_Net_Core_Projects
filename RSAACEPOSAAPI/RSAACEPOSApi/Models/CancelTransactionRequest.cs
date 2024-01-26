namespace RSAACEPOSApi.Models
{
    public class CancelTransactionRequest
    {
        public string sharedKey { get; set; }
        public string secret { get; set; }
        public string customer { get; set; }
        public int site { get; set; }
        public string transaction { get; set; }
        public int cashier { get; set; }
        public int terminal { get; set; }
        public string time { get; set; }
    }
}
