using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class MfgCoupon
    {
        public int MfgCouponId { get; set; }
        public string? OfferGuid { get; set; }
        public string? BrandName { get; set; }
        public string? OfferSummary { get; set; }
        public string? OfferValue { get; set; }
        public string? Upc { get; set; }
        public string? CouponImage { get; set; }
        public string? OfferDescription { get; set; }
        public DateTime? OfferActiveDate { get; set; }
        public DateTime? OfferExpiryDate { get; set; }
        public string? OfferType { get; set; }
        public int? MinQty { get; set; }
        public string? OfferFinePrint { get; set; }
        public string? OfferFeturedText { get; set; }
        public string? OfferDisclaimer { get; set; }
        public DateTime? OfferShutoffDate { get; set; }
        public long? SsnewsId { get; set; }
        public int? StatusId { get; set; }
        public int? CouponOfferId { get; set; }
        public bool? IsProcessedForNcr { get; set; }
        public string? OfferUpdateDate { get; set; }
    }
}
