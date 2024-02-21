using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ClientMessage
    {
        public ClientMessage()
        {
            ClientMessageTargets = new HashSet<ClientMessageTarget>();
            ClientMessagesDeleteds = new HashSet<ClientMessagesDeleted>();
        }

        public int MessageId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public int? CustomerId { get; set; }
        public bool? SendIphoneNotification { get; set; }
        public bool? SendAndroidNotification { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public bool? NotifyCustomersNow { get; set; }
        public int? MessageType { get; set; }
        public bool? IsTargetSpecific { get; set; }

        public virtual ICollection<ClientMessageTarget> ClientMessageTargets { get; set; }
        public virtual ICollection<ClientMessagesDeleted> ClientMessagesDeleteds { get; set; }
    }
}
