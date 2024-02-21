using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmJobHistory
    {
        public int LmJobHistoryId { get; set; }
        public DateTime? LastRunDateTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LogfileUrl { get; set; }
    }
}
