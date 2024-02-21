using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SsnewsProductsDeleted
    {
        public int Id { get; set; }
        public int? NewsId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
