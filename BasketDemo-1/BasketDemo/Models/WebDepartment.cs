using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class WebDepartment
    {
        public int WebDepartmentId { get; set; }
        public string? WebDepartmentName { get; set; }
        public string? WebDepartmentImage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
