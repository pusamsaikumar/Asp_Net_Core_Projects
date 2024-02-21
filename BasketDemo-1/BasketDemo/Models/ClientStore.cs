using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ClientStore
    {
        public int ClientStoreId { get; set; }
        public string StoreName { get; set; } = null!;
        public string? StoreProfile { get; set; }
        public int? StoreTypeId { get; set; }
        public string? StoreEmail { get; set; }
        public string? StorePhone { get; set; }
        public int? CompanyId { get; set; }
        public int? StoreGroupId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? Postype { get; set; }
        public string? PosrouteId { get; set; }
        public string? OtherPos { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PosvendorId { get; set; }
        public int? PossoftwareId { get; set; }
        public string? PossoftwareVersionNumber { get; set; }
        public string? ClientStorePosenterpriseSecretId { get; set; }
        public int? CustomerId { get; set; }
        public int? ClientEnterprisesRouteId { get; set; }
        public int? ClientEnterprisesId { get; set; }
        public string? StoreTimings { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? PosstoreId { get; set; }
        public int? GlobalStoreId { get; set; }
        public bool? IsActive { get; set; }

        public virtual ClientEnterprise? ClientEnterprises { get; set; }
    }
}
