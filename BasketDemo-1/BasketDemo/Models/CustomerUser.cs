using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class CustomerUser
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? UserDetailId { get; set; }
        public int? ContactTypeId { get; set; }

        public virtual ContactType? ContactType { get; set; }
    }
}
