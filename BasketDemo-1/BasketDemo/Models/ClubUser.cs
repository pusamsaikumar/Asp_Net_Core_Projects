using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ClubUser
    {
        public int Id { get; set; }
        public int? ClubId { get; set; }
        public int? UserId { get; set; }
        public string? ClubMemberId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsSubscribedToTopic { get; set; }

        public virtual Club? Club { get; set; }
    }
}
