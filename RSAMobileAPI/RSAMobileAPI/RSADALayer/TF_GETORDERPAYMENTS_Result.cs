namespace RSAMobileAPI.RSADALayer
{
    public class TF_GETORDERPAYMENTS_Result
    {
        public int OrderPaymentID { get; set; }
        public int? OrderID { get; set; }
        public int? PaymentTypeID { get; set; }
        public bool? PaymentConfirmation { get; set; }
        public decimal? Amount { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }   

    }
}




