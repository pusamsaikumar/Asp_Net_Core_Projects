using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class UserAdminStore
    {
        public int UserAdminStoreId { get; set; }
        public int? UserId { get; set; }
        public int? ClientStoreId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        public virtual UserDetail? User { get; set; }
    }
}
