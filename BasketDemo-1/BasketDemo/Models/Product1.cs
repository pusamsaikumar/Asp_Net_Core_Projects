using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Product1
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ProductCategory ProductCategory { get; set; } = null!;
    }
}
