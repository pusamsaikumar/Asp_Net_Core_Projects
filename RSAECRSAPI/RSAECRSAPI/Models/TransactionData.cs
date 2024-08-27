namespace RSAECRSAPI.Models
{
    public class TransactionData
    {

        public string SharedKey { get; set; }

        public string SecretKey { get; set; }

        public string Retailer { get; set; }

        public string Customer { get; set; }

        public int StoreId { get; set; }

        public string TransactionId { get; set; }

        public int Cashier { get; set; }

        public int Terminal { get; set; }

        public DateTime TransactionDate { get; set; }

        public TimeSpan TransactionTime { get; set; }

        public List<TransactionItem> Items { get; set; }

        public decimal TransactionTotalAmount { get; set; }

        public decimal TransactionTaxAmount { get; set; }

        public decimal TransactionGrossTotal { get; set; }

        public string PhoneNumber { get; set; }

        public List<TransactionTender> Tenders { get; set; }

        public string TenderType { get; set; }

        public string PosType { get; set; }

        public string DBInstanceName { get; set; }

        public string DBName { get; set; }

        public bool IsMemberTransaction { get; set; }

        public List<AppliedCoupon> Coupons { get; set; }

        public List<AppliedPromotion> Promotions { get; set; }

        public CommitData? CommitRequest { get; set; }

        public bool IsPOSDiscountApplied { get; set; }

        public string CloudRetailerName { get; set; }

        public string CloudFileName { get; set; }

        public string CloudFolderName { get; set; }
    }

    public class CommitData

    {

        public string SharedKey { get; set; }

        public string SecretKey { get; set; }

        public string Customer { get; set; }

        public int StoreId { get; set; }

        public string TransactionId { get; set; }

        public int Cashier { get; set; }

        public int Terminal { get; set; }

        public DateTime DateTime { get; set; }

        public List<string> Coupons { get; set; }

        public List<TransactionTender> Tenders { get; set; }

        public string TenderType { get; set; }

        public bool IsMemberTransaction { get; set; }

        public string CloudRetailerName { get; set; }

        public string CloudFileName { get; set; }

        public string CloudFolderName { get; set; }

    }

    public class AppliedCoupon

    {

        public string PromotionId { get; set; }

        public string IdType { get; set; }

        public string Title { get; set; }

        public List<CouponLineItem> Items { get; set; }

        public decimal TotalDiscount { get; set; }

        public int CouponTypeId { get; set; }

        public int AppliedCount { get; set; }

        public string CouponType { get; set; }

        public string CouponSource { get; set; }

        public string QualifiedLineIds { get; set; }

        public string QualifiedUPCs { get; set; }

        public bool IsAppliedAtPOS { get; set; }

    }

    public class AppliedPromotion

    {

        public string PromotionId { get; set; }

        public string IdType { get; set; }

        public string Title { get; set; }

        public List<CouponLineItem> Items { get; set; }

        public decimal TotalDiscount { get; set; }

        public int CouponTypeId { get; set; }

        public int AppliedCount { get; set; }

        public string CouponType { get; set; }

        public string CouponSource { get; set; }

        public string QualifiedLineIds { get; set; }

        public string QualifiedUPCs { get; set; }

        public bool IsAppliedAtPOS { get; set; }

    }

    public class TransactionItem

    {

        public int Id { get; set; }

        public string IdType { get; set; }

        public string UPC { get; set; }

        public decimal Amount { get; set; }

        public decimal StandardPrice { get; set; }

        public decimal AmountPaid { get; set; }

        public int Qty { get; set; }

        public string QtyType { get; set; }

        public decimal ItemWeight { get; set; }

        public string ItemType { get; set; }

        public int DeptId { get; set; }

        public string FamilyCode1 { get; set; }

        public string FamilyCode2 { get; set; }

        public string SaleType { get; set; }

        public string CoPrefix { get; set; }

        public string LineID { get; set; }

        public bool IsDiscountable { get; set; } //foodbazaar

        public string Weightunit { get; set; }// EX GRAMS, OUNCES, POUNDS, ETC. //foodbazaar



    }

    public class CouponLineItem

    {

        public int LineId { get; set; }

        public decimal DiscountAmount { get; set; }

        public int Quantity { get; set; }

    }

    public class TransactionTender

    {

        public string Type { get; set; }

        public decimal Amount { get; set; }

    }
}
