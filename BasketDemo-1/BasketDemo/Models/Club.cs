using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Club
    {
        public Club()
        {
            ClientMessageTargets = new HashSet<ClientMessageTarget>();
            ClubUsers = new HashSet<ClubUser>();
            LmRewardTargets = new HashSet<LmRewardTarget>();
            NewsTargets = new HashSet<NewsTarget>();
        }

        public int ClubId { get; set; }
        public string? Name { get; set; }
        public bool? IsMemberIdrequired { get; set; }
        public bool? IsEnableOnSignOn { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ClubDetails { get; set; }
        public string? TopicArn { get; set; }

        public virtual ICollection<ClientMessageTarget> ClientMessageTargets { get; set; }
        public virtual ICollection<ClubUser> ClubUsers { get; set; }
        public virtual ICollection<LmRewardTarget> LmRewardTargets { get; set; }
        public virtual ICollection<NewsTarget> NewsTargets { get; set; }
    }
}
