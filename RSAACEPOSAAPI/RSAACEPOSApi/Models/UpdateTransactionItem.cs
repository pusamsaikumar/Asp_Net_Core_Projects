using System.Runtime.Serialization;

namespace RSAACEPOSApi.Models
{
    public class UpdateTransactionItem
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int quantity { get; set; }
        [DataMember]
        public string upc { get; set; }
        [DataMember]
        public double price { get; set; }
        [DataMember]
        public double discountPrice { get; set; }
        [DataMember]
        public int dept { get; set; }
        [DataMember]
        public decimal weight { get; set; }
        [DataMember]
        public string weightunit { get; set; }// EX GRAMS, OUNCES, POUNDS, ETC. 
        [DataMember]
        public string itemType { get; set; } // EBT,Non EBT
        [DataMember]
        public bool isDiscountable { get; set; }
    }
}
