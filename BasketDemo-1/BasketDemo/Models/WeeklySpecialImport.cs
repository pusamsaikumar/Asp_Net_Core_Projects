using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class WeeklySpecialImport
    {
        public int WeeklySpecialImportId { get; set; }
        public string? Name { get; set; }
        public string? OfferDetails { get; set; }
        public string? Upc { get; set; }
        public string? ImageName { get; set; }
        public string? ProductName { get; set; }
        public string? Price { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime? ValidFromDate { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
    }
}
