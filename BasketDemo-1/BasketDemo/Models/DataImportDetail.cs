using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class DataImportDetail
    {
        public int DataImportDetailId { get; set; }
        public int DataImportId { get; set; }
        public string? CustomerCode { get; set; }
        public string? CouponCode { get; set; }
        public string? ProductCode { get; set; }
        public int? PurchaseCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
