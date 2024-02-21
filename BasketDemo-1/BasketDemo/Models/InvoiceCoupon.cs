using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class InvoiceCoupon
    {
        public int InvoiceCouponId { get; set; }
        public Guid CouponUniqueId { get; set; }
        public int InvoiceDetailId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? Modifieddate { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
