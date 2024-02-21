using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Product1s = new HashSet<Product1>();
            Products = new HashSet<Product>();
        }

        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public int? ClientDepartmentId { get; set; }
        public int? DefaultProductId { get; set; }
        public int? MajorDepartmentId { get; set; }

        public virtual ICollection<Product1> Product1s { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
