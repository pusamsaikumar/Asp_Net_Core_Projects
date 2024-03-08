namespace RSAMobileAPI.RSAEntities
{
    public class UserDetails :Entity
    {
        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public System.Guid CustomerId { get; set; }
        public int UserId { get; set; }
        public string CustomerCode { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeviceType { get; set; }
        public int DeviceId { get; set; }
        public int UserStatusId { get; set; }
        public bool IsDeleted { get; set; }
        public string BarCodeImage { get; set; }
        public string BarCodeValue { get; set; }
        public string QRCodeImage { get; set; }
        public string QRCodeValue { get; set; }
        public int? CompanyCustomerFK { get; set; }
        public int? UserTypeId { get; set; }
        public int? CompanyCustomerId { get; set; }
        public string ZipCode { get; set; }
        public int ClientId { get; set; }
        public int ClientStoreId { get; set; }
        public string QToken { get; set; }

        public string ExistingMemberNumber { get; set; }
    }
}
