namespace RSAMobileAPI.RSARepositories.Services
{
    public class UserDetail
    {
        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int? UserTypeId { get; set; }
        public int? CustomerID { get; set; }
        public Guid UserID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DeviceId { get; set; }
        public string DeviceType { get; set; }
        public int? UserStatusId { get; set; }
        public bool? IsDeleted { get; set; }
        public string BarCodeImage { get; set; }
        public string BarCodeValue { get; set; }
        public string ZipCode { get; set; }
        public int? ClientStoreId { get; set; }
        public string QToken { get; set; }
        public DateTime? SignUpDate { get; set; }
        public bool? NewTermsAcceptanceRequired { get; set; }
        public string AlternateMemberNumber { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
    }
}
