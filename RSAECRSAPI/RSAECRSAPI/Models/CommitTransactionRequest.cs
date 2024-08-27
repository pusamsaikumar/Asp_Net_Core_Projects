using System.Reflection;

namespace RSAECRSAPI.Models
{
    public class CommitTransactionRequest
    {
        public string SharedKey { get; set; }
        public string Secret { get; set; }
        public string Customer { get; set; }
        public int Site { get; set; }
        public string Transaction { get; set; }
        public int Cashier { get; set; }
        public int Terminal { get; set; }
        public string Time { get; set; }
        public List<string> coupons { get; set; }
        public List<Tender> tenders { get; set; }
    }
}
