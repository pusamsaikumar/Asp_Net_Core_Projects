using Microsoft.EntityFrameworkCore;

namespace RSAMobileAPI.RSADALayer
{
    [Keyless]
    public  class GetClientStores_App_Result
    {
        public int? ClientStoreId { get; set; }
        public string? StoreName { get; set; }
        public string? StoreProfile { get; set; }
        public Nullable<int> StoreTypeId { get; set; }
        public string? StoreEmail { get; set; }
        public string? StorePhone { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> StoreGroupId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> POSType { get; set; }
        public string? OtherPOS { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> POSVendorId { get; set; }
        public Nullable<int> POSSoftwareId { get; set; }
        public string? POSSoftwareVersionNumber { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> ClientEnterprisesRouteId { get; set; }
        public Nullable<int> ClientEnterprisesId { get; set; }
        public string? StoreTimings { get; set; }
        public Nullable<bool> EnableStoreManagement { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public string? StateName { get; set; }
        public int? UsersCount { get; set; }
        public int? WeeklyAdStoreId { get; set; }
        public Nullable<int> StoreNumber { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> StoreEcomStatus { get; set; }
        public int? Mealkitandroidstatus { get; set; }
        public int? Mealkitiosstatus { get; set; }
        public string? Mealkitlabel { get; set; }
        public int? Mealkitdeptnumber { get; set; }
        public Nullable<int> Ecomandroidstatus { get; set; }
        public int? Ecomiosstatus { get; set; }
       public string? Ecomlabel { get; set; }
    }
}
