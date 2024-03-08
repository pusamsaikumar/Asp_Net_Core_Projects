namespace RSAMobileAPI.RSADALayer
{
    public class TF_GETORDERDETAILS_Result
    {
        public int OrderDetailID { get; set; }  
        public int? OrderID { get; set; }
        public int? OrderItemID { get; set; }
        public int? NewsID { get; set; }
        public int? Qty { get;set; }
        public decimal? Price { get; set; } 
        public decimal? Amount { get; set;}
        public int? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }  
    }
}







