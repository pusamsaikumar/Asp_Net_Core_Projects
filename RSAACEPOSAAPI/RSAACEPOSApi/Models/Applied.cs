using System.Runtime.Serialization;

namespace RSAACEPOSApi.Models
{
    public class Applied
    {
        [DataMember]
        public string couponId { get; set; }
        [DataMember]
        public string externalId { get; set; }
        [DataMember]
        public string receiptAlias { get; set; }
        [DataMember]
      //  public List<Item> items { get; set; }
      
        public decimal totalDiscount { get; set; }
        [DataMember]
        public bool reducesTax { get; set; }
        [DataMember]
        public string overrideType { get; set; }
    }
}
