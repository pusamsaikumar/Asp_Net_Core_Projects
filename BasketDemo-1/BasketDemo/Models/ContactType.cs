using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ContactType
    {
        public ContactType()
        {
            Contacts = new HashSet<Contact>();
            CustomerUsers = new HashSet<CustomerUser>();
        }

        public int ContactTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<CustomerUser> CustomerUsers { get; set; }
    }
}
