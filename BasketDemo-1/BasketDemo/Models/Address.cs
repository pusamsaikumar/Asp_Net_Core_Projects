using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int AddressTypeId { get; set; }
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = null!;
        public int? StateId { get; set; }
        public string? Zip { get; set; }
        public int? CountryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        public virtual AddressType AddressType { get; set; } = null!;
    }
}
