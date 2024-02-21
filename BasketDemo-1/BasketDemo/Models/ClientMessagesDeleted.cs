using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ClientMessagesDeleted
    {
        public int MessageDeleteId { get; set; }
        public int? ClientMessageId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        public virtual ClientMessage? ClientMessage { get; set; }
    }
}
