using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class MyCart
    {
        public int CartId { get; set; }
        public int? OfferId { get; set; }
        public int? UserId { get; set; }
        public string? CategoryId { get; set; }
        public DateTime? RedeemOn { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsChecked { get; set; }
    }
}
