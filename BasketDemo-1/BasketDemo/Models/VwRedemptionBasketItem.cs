using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class VwRedemptionBasketItem
    {
        public int RetailerId { get; set; }
        public string? Upc { get; set; }
        public int? Qty { get; set; }
        public string? IdType { get; set; }
        public int BasketDataId { get; set; }
        public string? Retailer { get; set; }
        public int? Posid { get; set; }
        public int? StoreId { get; set; }
        public int? OperatorId { get; set; }
        public int? TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public TimeSpan? TransactionTime { get; set; }
        public int? TransactionTotalAmount { get; set; }
        public int? TransactionTaxAmount { get; set; }
        public string? TransactionTenderType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsProcessed { get; set; }
        public Guid? BasketGuid { get; set; }
        public int? IsUpcsplitComplete { get; set; }
        public bool? IsProcessedForMfg { get; set; }
        public int RedeemId { get; set; }
        public string? MemberNumber { get; set; }
        public string? OfferGuid { get; set; }
        public int? CouponOfferId { get; set; }
        public string? ProductName { get; set; }
        public int? GlobalStoreId { get; set; }
        public int? ClearingStatusId { get; set; }
        public int? ClearingRecordId { get; set; }
    }
}
