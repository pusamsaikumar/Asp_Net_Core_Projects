using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmRewardDepartment
    {
        public int LmrewardDepartmentId { get; set; }
        public int LmrewardId { get; set; }
        public int DepartmentNumber { get; set; }
        public bool? IsExclude { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public int UpdateUserId { get; set; }
        public int CreateUserId { get; set; }
        public int? LmdepartmentExcludeTypeId { get; set; }
    }
}
