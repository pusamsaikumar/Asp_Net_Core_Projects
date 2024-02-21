using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class RsaTransactionHistory
    {
        public int TransactionHistoryId { get; set; }
        public int? RewardId { get; set; }
        public int? VersionId { get; set; }
        public string? Json { get; set; }
        public int? TypeId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
