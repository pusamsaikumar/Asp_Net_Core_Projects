using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class UserToken
    {
        public long UserTokenId { get; set; }
        public long UserId { get; set; }
        public string LoginToken { get; set; } = null!;
        public DateTime LastAccessed { get; set; }
        public short? DeviceId { get; set; }
        public string? DeviceInfo { get; set; }
        public string? DeviceRegistrationId { get; set; }
        public string? MobileOs { get; set; }
        public string? MobileOsversion { get; set; }
        public string? MobileModel { get; set; }
    }
}
