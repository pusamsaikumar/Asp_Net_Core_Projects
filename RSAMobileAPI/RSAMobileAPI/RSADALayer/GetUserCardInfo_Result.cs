namespace RSAMobileAPI.RSADALayer
{
    public class GetUserCardInfo_Result
    {
        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        public string BarcodeValue { get; set; }
        public string BarcodeImage { get; set; }
        public decimal? TotalPurchaseAmount { get; set; }
        public decimal? RedeemAmount { get; set; }
    }
}
