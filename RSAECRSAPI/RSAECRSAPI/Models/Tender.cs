namespace RSAECRSAPI.Models
{
    public class Tender
    {
        public string Type { get; set; }

        public double Amount { get; set; }

        public string Bin { get; set; } //// The first 6 digits of the payment card that was swiped.

        public string Pan { get; set; } ////The last four digits of the PAN (Primary account number or Credit card number)

        public string Approvalcode { get; set; } //// Authorization code from Retailer PoS

        public string Paymentdatetime { get; set; } //// The time that the POS transaction was finalized. Should be the actual transaction time (card swipe time), not the time the retailer system finished processing or resolving the transaction. 
    }
}
