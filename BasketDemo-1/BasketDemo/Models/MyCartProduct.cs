using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class MyCartProduct
    {
        public int MyCartProductId { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public int? Quantity { get; set; }
        public bool? IsChecked { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UserAddedItem { get; set; }
    }
}
