using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class UserStatus
    {
        public short UserStatusId { get; set; }
        public string UserStatusDesc { get; set; } = null!;
    }
}
