using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = null!;
        public int CustomerId { get; set; }
        public int? ProductCategoryId { get; set; }
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
        public int? ManufacturerId { get; set; }

        public virtual ProductCategory? ProductCategory { get; set; }
    }
}
