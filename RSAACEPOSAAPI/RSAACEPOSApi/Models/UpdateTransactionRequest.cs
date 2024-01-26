using System.Runtime.Serialization;

namespace RSAACEPOSApi.Models
{
    public class UpdateTransactionRequest
    {
        public string sharedKey { get; set; }


        public string secret { get; set; }


        public string customer { get; set; }


        public int site { get; set; }


        public string transaction { get; set; }


        public int cashier { get; set; }


        public int terminal { get; set; }


        public string time { get; set; }

        [DataMember]

       public List<UpdateTransactionItem> items { get; set; }


        public double subTotal { get; set; }

       

        public double taxTotal { get; set; }

       

        public double grossTotal { get; set; }

      

        public string phoneNumber { get; set; }

        [DataMember]

        public bool posDiscountApplied { get; set; }
    }
}
