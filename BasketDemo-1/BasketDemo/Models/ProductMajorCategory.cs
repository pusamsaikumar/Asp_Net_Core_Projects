using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ProductMajorCategory
    {
        public int ProductMajorCategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public int? ClientMajorDepartmentId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public string? DepartmentImageName { get; set; }
    }
}
