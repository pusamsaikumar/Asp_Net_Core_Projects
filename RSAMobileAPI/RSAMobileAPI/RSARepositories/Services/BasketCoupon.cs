namespace RSAMobileAPI.RSARepositories.Services
{
    public class BasketCoupon
    {
        public int BasketCouponId { get; set; }
        public int BasketDataId { get; set; }
        public string CouponID { get; set; }
        public string IdType { get; set; }
        public string CouponType { get; set; }
        public decimal CouponValue { get; set; }
        public string CouponSource { get; set; }
        public int IncentiveId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RedeemCount { get; set; }
    }
}
