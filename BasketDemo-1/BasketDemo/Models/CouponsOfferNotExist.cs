using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class CouponsOfferNotExist
    {
        public string OfferIdguid { get; set; } = null!;
        public string? Retailer { get; set; }
        public int? OfferId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int MpmId { get; set; }
    }
}
