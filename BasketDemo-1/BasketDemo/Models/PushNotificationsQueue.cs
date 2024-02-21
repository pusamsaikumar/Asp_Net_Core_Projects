using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class PushNotificationsQueue
    {
        public long PushNotificationsQueueId { get; set; }
        public int? MessageId { get; set; }
        public int? UserId { get; set; }
        public bool? IsViewed { get; set; }
        public bool? IPhoneNotificationSent { get; set; }
        public bool? AndriodNotificationSent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? IPhoneNotificationDate { get; set; }
        public DateTime? AndriodNotificationDate { get; set; }
        public string? PickUpControlNumber { get; set; }
    }
}
