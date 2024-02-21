using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ClubsDeleted
    {
        public int ClubsDeletedId { get; set; }
        public int ClubId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int CreateUserId { get; set; }
    }
}
