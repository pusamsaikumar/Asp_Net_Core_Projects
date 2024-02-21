using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ClientEnterprise
    {
        public ClientEnterprise()
        {
            ClientEnterpriseRoutes = new HashSet<ClientEnterpriseRoute>();
            ClientStores = new HashSet<ClientStore>();
        }

        public int ClientEnterprisesId { get; set; }
        public string? Name { get; set; }
        public string? PosenterpriseId { get; set; }
        public string? PosenterpriseSecretKey { get; set; }
        public int? PosvendorId { get; set; }
        public string? Possoftware { get; set; }
        public int? CustomerId { get; set; }

        public virtual ICollection<ClientEnterpriseRoute> ClientEnterpriseRoutes { get; set; }
        public virtual ICollection<ClientStore> ClientStores { get; set; }
    }
}
