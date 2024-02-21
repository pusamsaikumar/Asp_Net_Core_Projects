using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SalesHeader
    {
        public int SalesHeaderId { get; set; }
        public string? MemberNumber { get; set; }
        public string? TransactionAmount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
