using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SelectedStoresForIntelligentCoupon
    {
        public int Id { get; set; }
        public int CouponId { get; set; }
        public string? StoreRouteId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ClientStoreId { get; set; }
        public string? EnterpriseId { get; set; }
    }
}
