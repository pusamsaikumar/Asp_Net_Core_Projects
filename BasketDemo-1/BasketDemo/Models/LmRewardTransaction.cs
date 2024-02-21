using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmRewardTransaction
    {
        public int LmRewardTransactionsId { get; set; }
        public string? MemberNumber { get; set; }
        public string? Lmsubject { get; set; }
        public string? Lmmessage { get; set; }
        public string? MessageType { get; set; }
        public int? TransactionNumber { get; set; }
        public string? TransactionType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
