using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class LmUserReward
    {
        public int Id { get; set; }
        public string MemberNumber { get; set; } = null!;
        public int LmrewardId { get; set; }
        public DateTime AppliedDate { get; set; }
        public int SsnewsId { get; set; }
        public int StatusId { get; set; }
    }
}
