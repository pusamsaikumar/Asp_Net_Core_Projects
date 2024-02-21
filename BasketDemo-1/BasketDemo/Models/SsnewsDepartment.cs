using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SsnewsDepartment
    {
        public int Id { get; set; }
        public int? NewsId { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsMajorDepartment { get; set; }

        public virtual Ssnews? News { get; set; }
    }
}
