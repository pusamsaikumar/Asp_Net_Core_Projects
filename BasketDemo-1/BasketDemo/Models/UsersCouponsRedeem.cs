using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class UsersCouponsRedeem
    {
        public int Id { get; set; }
        public int CouponId { get; set; }
        public int UserId { get; set; }
        public DateTime? RedeemOn { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpiresOn { get; set; }
    }
}
