namespace RSAMobileAPI.RSADALayer
{
    public class TF_GetAllMenu_Result
    {
        public int NewsID { get; set; }
        public int? NewsCategoryID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string ProductImage { get; set; }
        public string ImagePath { get; set; }
        public DateTime? ValidFromDate { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public bool? SendNotification { get; set; }
        public int? CustomerID { get; set; }
        public int? CreateUserID { get; set; }
        public int? UpdateUserID { get; set; }
        public string CustomerName { get; set; }
        public string CategoryName { get; set; }
        public string PUICode { get; set; }
        public Guid? CouponUniqueId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Amount { get; set; }
        public string ProductName { get; set; }
        public string CouponCode { get; set; }
        public decimal? DiscountAmount { get; set; }
        public bool? IsDiscountPercentage { get; set; }
        public string NCRPromotionCode { get; set; }
        public DateTime? NCRPromotionCreatedDate { get; set; }
        public DateTime? RedeemOn { get; set; }
        public  int? IsExpired { get; set; }
        public int ISRedeemed { get; set; }
        public int IsInCart { get; set; }
        public int IsInNCRImpression { get; set; }
        public bool? IsFeatured { get; set; }
        public int ProductCategoryId { get; set; }
        public string SpecialPrice { get; set; }
        public string DepartmentName { get; set; }
        public bool? NewTermsAcceptanceRequired { get; set; }
    }
}
