using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SsnewsUsersRedeem
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public DateTime? RedeemOn { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpiresOn { get; set; }
    }
}
