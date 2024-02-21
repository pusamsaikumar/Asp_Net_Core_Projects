using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class MfgCouponsHoldStore
    {
        public int MfgCouponHoldStoreId { get; set; }
        public int MfgCouponHoldId { get; set; }
        public int StoreId { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int? CouponOfferId { get; set; }
        public bool? StatusId { get; set; }
    }
}
