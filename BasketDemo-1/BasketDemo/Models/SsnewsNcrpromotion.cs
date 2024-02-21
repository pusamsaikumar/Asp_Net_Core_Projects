using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SsnewsNcrpromotion
    {
        public int Id { get; set; }
        public int? SsnewsId { get; set; }
        public string? NcrpromotionId { get; set; }
        public string? EnterpriseId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
