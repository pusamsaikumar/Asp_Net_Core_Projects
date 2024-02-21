using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SubCategory
    {
        public int Id { get; set; }
        public int? SubDepartmentId { get; set; }
        public string? SubDepartmentName { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
