using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? FederalId { get; set; }
        public int? CustomerTypeId { get; set; }
        public string? Siccode { get; set; }
        public int? CompanyId { get; set; }
        public string? CustomerProfile { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerWebSite { get; set; }
        public string? CustomerLogo { get; set; }
        public string? PrimaryColor { get; set; }
        public string? SecondaryColor { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? PaymentTermsId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public Guid? CustomerGuid { get; set; }
        public decimal? BillingPercentage { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPosintegrationEnabled { get; set; }
        public bool? EnableStoreManagement { get; set; }
        public bool? EnableManufacturerCoupons { get; set; }
        public bool? EnableProductCouponPrice { get; set; }
        public bool? EnableRecipes { get; set; }
        public bool? EnableClubs { get; set; }
        public bool? EnableCustomersAlsoBoughtTheseItems { get; set; }
        public bool? EnableTargets { get; set; }
        public bool? ShowPriceForSpecials { get; set; }
        public bool? EnableGroupBasket { get; set; }
        public bool? EnableBogoCoupon { get; set; }
        public bool? ShowTotalSavings { get; set; }
        public bool? EnableRecurringCoupon { get; set; }
        public bool? EnableUserManagement { get; set; }
        public int? MaxNoOfGroups { get; set; }
        public bool? EnableDepartmentsInBasketCoupon { get; set; }
        public string? MfgcontentAppId { get; set; }
        public bool? EnableStoresForWeeklyAds { get; set; }
    }
}
