using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class AddressType
    {
        public AddressType()
        {
            Addresses = new HashSet<Address>();
        }

        public int AddressTypeId { get; set; }
        public string AddressType1 { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
