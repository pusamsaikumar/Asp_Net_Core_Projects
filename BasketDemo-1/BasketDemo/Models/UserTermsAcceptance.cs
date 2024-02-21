using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class UserTermsAcceptance
    {
        public int UserTermsAcceptanceId { get; set; }
        public int? UserId { get; set; }
        public DateTime? AcceptDateTime { get; set; }
        public int? DeviceId { get; set; }
        public string? DeviceInfo { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
