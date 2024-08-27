namespace RSAECRSAPI.ECRSDAL.Models
{
    public class CancelTransactionRequest
    {
        public string SharedKey { get; set; }
        public string Secret { get; set; }
        public string Customer { get; set; }
        public int Site { get; set; }
        public string Transaction { get; set; }
        public int Cashier { get; set; }
        public int Terminal { get; set; }
        public string Time { get; set; }
    }
}
