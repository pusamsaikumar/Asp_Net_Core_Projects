namespace RSAMobileAPI.RSARepositories.Services
{
    public class GetUserCouponsForRedeem_Result
    {
        public int CouponId { get; set; }
        public System.Guid CouponUniqueId { get; set; }
        public string CouponCode { get; set; }
        public int Customer_Id { get; set; }
        public int UserDetailId { get; set; }
        public int ProductId { get; set; }
        public int NoDiscountCount { get; set; }
        public int UpSellCount { get; set; }
        public Nullable<decimal> DiscountPercentageCount { get; set; }
        public int CouponStatusId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<System.DateTime> RedeemOn { get; set; }
        public string Customername { get; set; }
        public int NoDiscountProductId { get; set; }
        public Nullable<int> UpSellProductId { get; set; }
        public string NoDiscountProductName { get; set; }
        public string UpSellProductName { get; set; }
        public string UpSellProductImage { get; set; }
        public Nullable<decimal> UpSellSalePrice { get; set; }
        public string UpSellProductCode { get; set; }
        public string CouponStatus { get; set; }
        public Nullable<bool> IsDiscountaPercentage { get; set; }
        public string NCRPromotionCode { get; set; }
        public Nullable<System.DateTime> NCRPromotionCreatedDate { get; set; }
        public Nullable<System.DateTime> CouponsRedeemOn { get; set; }
        public Nullable<int> IsExpired { get; set; }
        public int ISRedeemed { get; set; }
        public int IsInCart { get; set; }
        public int IsInNCRImpression { get; set; }
        public string PromotionId { get; set; }
    }

}
