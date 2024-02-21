using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ClientMessageTarget
    {
        public int MessageTargetId { get; set; }
        public int? MessageId { get; set; }
        public int? ClubId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsExclude { get; set; }

        public virtual Club? Club { get; set; }
        public virtual ClientMessage? Message { get; set; }
    }
}
