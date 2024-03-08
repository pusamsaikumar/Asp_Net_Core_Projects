namespace RSAMobileAPI.RSADALayer
{
    public class TF_GETORDERS_Result
    {
        public int OrderID { get; set; }    
        public int?  UserID { get; set; }   
        public string OrderNumber { get; set; } 
        public DateTime? OrderDate { get; set; }
        public int? ShippingAddressID { get; set; } 
        public DateTime? DeliveryDate { get; set; }
        public int? ServicingLocationID  { get; set;}
        public int? CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}









