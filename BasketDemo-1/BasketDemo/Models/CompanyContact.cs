using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class CompanyContact
    {
        public int RowId { get; set; }
        public int CompanyId { get; set; }
        public int UserDetailId { get; set; }
        public int? ContactTypeId { get; set; }
    }
}
