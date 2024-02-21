using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class TimeZone
    {
        public short TimeZoneId { get; set; }
        public string? Id { get; set; }
        public string? BaseUtcOffSet { get; set; }
        public string? DaylightName { get; set; }
        public string? DisplayName { get; set; }
        public string? StandardName { get; set; }
        public short? SupportsDayLightSavingTime { get; set; }
        public string? IphoneTimeZoneName { get; set; }
    }
}
