using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SalesRedeem
    {
        public int RedeemSno { get; set; }
        public string? RedeemId { get; set; }
        public string? PromotionId { get; set; }
        public string? PromotionName { get; set; }
        public string? RedeemEnterpriseId { get; set; }
        public string? RedeemName { get; set; }
        public DateTime? RedeemDateTime { get; set; }
        public string? RedeemType { get; set; }
        public string? RedeemAmount { get; set; }
        public string? Customer { get; set; }
        public string? RedeemStoreNumber { get; set; }
        public string? RedeemLaneNumber { get; set; }
        public string? RedeemTransactionNumber { get; set; }
        public string? OneTimeRedeemCode { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
