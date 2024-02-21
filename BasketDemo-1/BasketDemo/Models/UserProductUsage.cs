using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class UserProductUsage
    {
        public int UserProductUsageId { get; set; }
        public int UserDetailId { get; set; }
        public int ProductId { get; set; }
        public int DataImportId { get; set; }
        public int PurchaseCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
