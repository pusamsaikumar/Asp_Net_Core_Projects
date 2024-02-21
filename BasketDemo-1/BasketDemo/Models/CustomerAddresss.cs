using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class CustomerAddresss
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? AddressId { get; set; }
    }
}
