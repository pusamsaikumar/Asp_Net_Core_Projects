using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            UserAdminStores = new HashSet<UserAdminStore>();
        }

        public int UserDetailId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Mobile { get; set; }
        public int? UserTypeId { get; set; }
        public int? CustomerId { get; set; }
        public Guid UserId { get; set; }
        public int? XUserId { get; set; }
        public string XCustomerCode { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? DeviceId { get; set; }
        public string? DeviceType { get; set; }
        public int? UserStatusId { get; set; }
        public bool? IsDeleted { get; set; }
        public string? BarCodeImage { get; set; }
        public string? BarCodeValue { get; set; }
        public string? QrcodeImage { get; set; }
        public string? QrcodeValue { get; set; }
        public string? ZipCode { get; set; }
        public int? ClientStoreId { get; set; }
        public string? Qtoken { get; set; }
        public DateTime? SignUpDate { get; set; }
        public bool? NewTermsAcceptanceRequired { get; set; }
        public string? AlternateMemberNumber { get; set; }
        public string? CustomField1 { get; set; }
        public string? CustomField2 { get; set; }

        public virtual ICollection<UserAdminStore> UserAdminStores { get; set; }
    }
}
