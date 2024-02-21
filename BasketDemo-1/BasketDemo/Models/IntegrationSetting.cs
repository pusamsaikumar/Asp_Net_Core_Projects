using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class IntegrationSetting
    {
        public int IntegrationSettingId { get; set; }
        public int? PosId { get; set; }
        public int? DataExchangeFrequencyId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? ScheduleTime { get; set; }
        public string? CouponExportLocation { get; set; }
        public string? CouponExportUserId { get; set; }
        public string? CouponExportUserPassword { get; set; }
        public string? DailySalesFileLocation { get; set; }
        public string? DailySalesImportUserId { get; set; }
        public string? DailySalesImportUserPassword { get; set; }
        public bool? IsCroseAllowed { get; set; }
        public string? CustomField1 { get; set; }
        public string? CustomField2 { get; set; }
        public string? CustomField3 { get; set; }
        public string? CustomField4 { get; set; }
        public string? CustomField5 { get; set; }
        public string? CustomField6 { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
