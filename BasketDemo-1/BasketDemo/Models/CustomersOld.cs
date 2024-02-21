using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class CustomersOld
    {
        public CustomersOld()
        {
            CustomerContacts = new HashSet<CustomerContact>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }
    }
}
