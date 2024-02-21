using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class CustomerContact
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ContactId { get; set; }

        public virtual Contact? Contact { get; set; }
        public virtual CustomersOld? Customer { get; set; }
    }
}
