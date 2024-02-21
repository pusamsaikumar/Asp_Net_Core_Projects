using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Contact
    {
        public Contact()
        {
            CustomerContacts = new HashSet<CustomerContact>();
        }

        public int Id { get; set; }
        public int ContactTypeId { get; set; }
        public string Phone { get; set; } = null!;
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        public virtual ContactType ContactType { get; set; } = null!;
        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }
    }
}
