using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public int? InvoiceId { get; set; }
        public DateTime? InvoicePeriodFrom { get; set; }
        public DateTime? InvoicePeriodTo { get; set; }
        public decimal? Amount { get; set; }
        public int? RedeamedCouponCount { get; set; }
    }
}
