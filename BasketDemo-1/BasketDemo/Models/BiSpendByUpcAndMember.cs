using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class BiSpendByUpcAndMember
    {
        public long SpendByUpcMemberId { get; set; }
        public string? MemberNumber { get; set; }
        public string? Upc { get; set; }
        public int? DeptId { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? TotalQty { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
