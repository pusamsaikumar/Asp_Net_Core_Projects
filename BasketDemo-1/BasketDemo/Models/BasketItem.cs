using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class BasketItem
    {
        public int BasketItemId { get; set; }
        public int? BasketDataId { get; set; }
        public string? Upc { get; set; }
        public string? IdType { get; set; }
        public int? Amount { get; set; }
        public int? DeptId { get; set; }
        public int? Qty { get; set; }
        public string? QtyType { get; set; }
        public string? SaleType { get; set; }
        public string? CoPrefix { get; set; }
        public string? FamilyCode1 { get; set; }
        public string? FamilyCode2 { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
