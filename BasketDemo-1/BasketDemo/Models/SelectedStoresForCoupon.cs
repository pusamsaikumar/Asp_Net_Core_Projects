using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SelectedStoresForCoupon
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string? StoreRouteId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ClientStoreId { get; set; }
        public string? EnterpriseId { get; set; }
    }
}
