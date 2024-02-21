using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Ssnews
    {
        public Ssnews()
        {
            NewsTargets = new HashSet<NewsTarget>();
            SelectedProductIdForWeeklySpecials = new HashSet<SelectedProductIdForWeeklySpecial>();
            SsnewsDepartments = new HashSet<SsnewsDepartment>();
            SsnewsRecurrings = new HashSet<SsnewsRecurring>();
            WeeklySpecialsExtensions = new HashSet<WeeklySpecialsExtension>();
        }

        public int NewsId { get; set; }
        public int? NewsCategoryId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? ValidFromDate { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public bool? SendNotification { get; set; }
        public int? CustomerId { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public Guid? CouponUniqueId { get; set; }
        public string? Puicode { get; set; }
        public int? ProductId { get; set; }
        public decimal? Amount { get; set; }
        public string? CouponCode { get; set; }
        public decimal? DiscountAmount { get; set; }
        public bool? IsDiscountPercentage { get; set; }
        public string? NcrpromotionCode { get; set; }
        public DateTime? NcrpromotionCreatedDate { get; set; }
        public bool? IsItStoreSpecific { get; set; }
        public long? ManufacturerCouponId { get; set; }
        public int? ProductQuantity { get; set; }
        public int? UpSellProductId { get; set; }
        public int? UpSellProductQuantity { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? IsItTargetSpecific { get; set; }
        public string? OtherDetails { get; set; }
        public int? JsonPageId { get; set; }
        public bool? IsRecurring { get; set; }
        public long? RecurringId { get; set; }
        public DateTime? MfgShutOffDate { get; set; }
        public int NewsStatusId { get; set; }
        public bool? IsItDepartmentSpecific { get; set; }
        public bool? IsDealOftheWeek { get; set; }
        public int? ParentNewsId { get; set; }
        public int? CouponLimit { get; set; }

        public virtual ICollection<NewsTarget> NewsTargets { get; set; }
        public virtual ICollection<SelectedProductIdForWeeklySpecial> SelectedProductIdForWeeklySpecials { get; set; }
        public virtual ICollection<SsnewsDepartment> SsnewsDepartments { get; set; }
        public virtual ICollection<SsnewsRecurring> SsnewsRecurrings { get; set; }
        public virtual ICollection<WeeklySpecialsExtension> WeeklySpecialsExtensions { get; set; }
    }
}
