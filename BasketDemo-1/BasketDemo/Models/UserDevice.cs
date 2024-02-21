using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class UserDevice
    {
        public int Id { get; set; }
        public int UserDetailId { get; set; }
        public string DeviceId { get; set; } = null!;
        public int DeviceTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
