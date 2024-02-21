using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public string? InvoiceNumber { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? CustomerPaymentTermsId { get; set; }
        public string? Description { get; set; }
        public DateTime? InvoicePeriodFrom { get; set; }
        public DateTime? InvoicePeriodTo { get; set; }
        public decimal? Amount { get; set; }
        public int? StatusId { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? DynamicsReferenceNumber { get; set; }
        public bool? IsSentToDynamics { get; set; }
        public DateTime? SentToDynamicsOn { get; set; }
        public string? Memo { get; set; }
    }
}
