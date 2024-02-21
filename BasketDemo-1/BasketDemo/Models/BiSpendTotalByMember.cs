using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class BiSpendTotalByMember
    {
        public long SpendTotalByMemberId { get; set; }
        public string? MemberNumber { get; set; }
        public decimal? BasketAmount { get; set; }
        public int? BasketCount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
