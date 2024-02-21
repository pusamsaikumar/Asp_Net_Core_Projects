using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class RedemptionDistributionJson
    {
        public int RdjsonId { get; set; }
        public string? RedemptionJson { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Rdstatus { get; set; }
    }
}
