using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class BasketDataJson
    {
        public int BasketDataJsonid { get; set; }
        public int BasketDataId { get; set; }
        public string? BasketJson { get; set; }
        public bool? IsItDuplicateTransaction { get; set; }
    }
}
