using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class UserDeviceInfo
    {
        public int UserDeviceInfoId { get; set; }
        public int? UserId { get; set; }
        public int? DeviceId { get; set; }
        public string? DeviceInfo { get; set; }
        public string? Awsarn { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
