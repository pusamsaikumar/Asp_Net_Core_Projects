using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Company1
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string? FederalId { get; set; }
        public int? PrimaryContactId { get; set; }
        public int? SecondaryContactId { get; set; }
        public string? Description { get; set; }
        public int? MaillingAddressId { get; set; }
        public int? BillingAddressId { get; set; }
        public bool? IsBillingSameAsMailingAddress { get; set; }
        public short? CountryId { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? LogoFileUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public string? CompanyMailId { get; set; }
    }
}
