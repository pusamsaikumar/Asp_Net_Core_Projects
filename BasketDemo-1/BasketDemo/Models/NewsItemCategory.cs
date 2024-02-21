using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class NewsItemCategory
    {
        public short NewsItemCategoryId { get; set; }
        public string Description { get; set; } = null!;
    }
}
