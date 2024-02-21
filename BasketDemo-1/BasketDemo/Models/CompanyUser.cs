using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class CompanyUser
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int? UserDetailId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
