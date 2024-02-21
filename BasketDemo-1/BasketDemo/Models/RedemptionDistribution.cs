using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class RedemptionDistribution
    {
        public int Id { get; set; }
        public string? DirectiveType { get; set; }
        public string? DistributionOfferAlias { get; set; }
        public string? RedeemId { get; set; }
        public string? RedeemEnterpriseId { get; set; }
        public string? PromotionId { get; set; }
        public string? RedeemType { get; set; }
        public string? Customer { get; set; }
        public string? RedeemAmount { get; set; }
        public string? DirectiveId { get; set; }
        public string? MemberNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? RedemptionDate { get; set; }
        public int? RdjsonId { get; set; }
        public int? BasketDataId { get; set; }
        public int? StatusId { get; set; }
    }
}
