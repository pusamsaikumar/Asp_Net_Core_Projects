using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ProductImport
    {
        public string ProductCode { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? ProductCategory { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int? SellingUnitId { get; set; }
        public int? BuyingUnitId { get; set; }
        public decimal? SalePrice { get; set; }
        public bool? IsDiscountAllowed { get; set; }
        public string? Sku { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string? ProductImage { get; set; }
        public string? BarCodeImage { get; set; }
        public string? BarCodeValue { get; set; }
    }
}
