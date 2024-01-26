using System.Runtime.Serialization;

namespace RSAACEPOSApi.Models
{
    public class Tender
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public double amount { get; set; }
        [DataMember]
        public string bin { get; set; } //// The first 6 digits of the payment card that was swiped.
        [DataMember]
        public string pan { get; set; } ////The last four digits of the PAN (Primary account number or Credit card number)
        [DataMember]
        public string approvalcode { get; set; } //// Authorization code from Retailer PoS
        [DataMember]
        public string paymentdatetime { get; set; } //// The time that the POS transaction was finalized. Should be the actual transaction time (card swipe time), not the time the retailer system finished processing or resolving the transaction. 
    }
}
