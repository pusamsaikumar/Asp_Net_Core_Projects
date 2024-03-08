using System.ComponentModel.DataAnnotations;

namespace RSAMobileAPI.RSADALayer
{
    public  class GetClientStores_Result
    {
     
        public int ClientStoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreProfile { get; set; }
        public int? StoreTypeId { get; set; }
        public string StoreEmail { get; set; }
        public string StorePhone { get; set; }
        public int CompanyId { get; set; }
        public int? StoreGroupId { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? POSType { get; set; }
        public string? OtherPOS { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? POSVendorId { get; set; }
        public int? POSSoftwareId { get; set; }
        public string POSSoftwareVersionNumber { get; set; }
        public int? CustomerId { get; set; }
        public int? ClientEnterprisesRouteId { get; set; }
        public int? ClientEnterprisesId { get; set; }
        public string StoreTimings { get; set; }
        public bool? EnableStoreManagement { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string StateName { get; set; }
        public int? UsersCount { get; set; }
        public int WeeklyAdStoreId { get; set; }
        public int? StoreNumber { get; set; }
        public bool? IsActive { get; set; }
       // public bool? StoreEcomStatus { get; set; }
    }
}

    //public class GetClientStores_Result
    //{
    //    public int ClientStoreId { get; set; }
    //    public string StoreName { get; set; }
    //    public string StoreProfile { get; set; }
    //    public int StoreTypeId { get; set; }
    //    public string StoreEmail { get; set; }
    //    public string StorePhone { get; set; }
    //    public int CompanyId { get; set; }
    //    public int StoreGroupId { get; set; }
    //    public string AddressLine1 { get; set; }
    //    public string AddressLine2 { get; set; }
    //    public string City { get; set; }
    //    public string ZipCode { get; set; }
    //    public int CountryId { get; set; }
    //    public int StateId { get; set; }
    //    public int POSType { get; set; }
    //    public string OtherPOS { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public int POSVendorId { get; set; }
    //    public int POSSoftwareId { get; set; }
    //    public string POSSoftwareVersionNumber { get; set; }
    //    public int CustomerId { get; set; }
    //    public int ClientEnterprisesRouteId { get; set; }
    //    public int ClientEnterprisesId { get; set; }
    //    public string StoreTimings { get; set; }
    //    public bool EnableStoreManagement { get; set; }
    //    public decimal Latitude { get; set; }
    //    public decimal Longitude { get; set; }
    //    public string StateName { get; set; }
    //    public int UsersCount { get; set; }
    //    public int WeeklyAdStoreId { get; set; }
    //    public int StoreNumber { get; set; }
    //    public bool IsActive { get; set; }
    //    public bool StoreEcomStatus { get; set; }
      
    //}
//}
