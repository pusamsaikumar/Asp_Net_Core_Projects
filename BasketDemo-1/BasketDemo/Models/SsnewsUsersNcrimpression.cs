using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SsnewsUsersNcrimpression
    {
        public int NcrimpressionId { get; set; }
        public int? NewsId { get; set; }
        public int? UserId { get; set; }
        public string? NcrimpressionCode { get; set; }
        public DateTime? NcrimpressionDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
