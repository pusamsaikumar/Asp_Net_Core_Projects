using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SalesHeaderDetail
    {
        public int SalesHeaderDetailId { get; set; }
        public int? SalesHeaderId { get; set; }
        public string? ProductUpc { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string? NcrpromotionId { get; set; }
        public bool? IsProcessed { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
