using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? FederalId { get; set; }
        public string? CompanyProfile { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyEmail { get; set; }
        public string? CompanyWebSite { get; set; }
        public string? CompanyLogo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
