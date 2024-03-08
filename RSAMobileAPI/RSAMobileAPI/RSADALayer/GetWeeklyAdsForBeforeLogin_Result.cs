namespace RSAMobileAPI.RSADALayer
{
    public class GetWeeklyAdsForBeforeLogin_Result
    {
        public int NewsID {  get; set; }
        public int? NewsCategoryID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; } 
        public string ProductImage { get; set; }  
        public string ImagePath { get; set; }   
        public DateTime? ValidFromDate { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public int? CreateUserID { get; set; }
        public string CategoryName { get; set; }
        public int? ProductId { get; set; }
        public decimal? Amount { get; set; }
        public string ProductName { get; set; }
        public decimal?  DiscountAmount { get; set; }
        public bool? IsDiscountPercentage { get; set; }
        public int IsExpired { get; set; }
        public int ISRedeemed { get; set; }
        public int IsInCart { get; set; }
        public bool? IsFeatured { get; set; }
        public int ProductCategoryId { get; set; }
        public string SpecialPrice { get; set; }
        public string DepartmentName { get; set; }
    }
    
   
    
    


   
}
