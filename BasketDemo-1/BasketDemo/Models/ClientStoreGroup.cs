using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ClientStoreGroup
    {
        public int ClientStoreGroupsId { get; set; }
        public string? StoreGroupName { get; set; }
        public int? StoreGroupAdministrator { get; set; }
        public string? StoreGroupDescription { get; set; }
    }
}
