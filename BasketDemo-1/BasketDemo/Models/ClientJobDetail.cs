using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ClientJobDetail
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? JobIntervalTypeId { get; set; }
        public DateTime? JobStartDate { get; set; }
        public DateTime? LastRunDate { get; set; }
        public bool? SalesImport { get; set; }
        public bool? CouponExport { get; set; }
    }
}
