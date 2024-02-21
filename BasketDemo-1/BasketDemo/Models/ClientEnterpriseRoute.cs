using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ClientEnterpriseRoute
    {
        public int ClientEnterpriseRouteId { get; set; }
        public string? Name { get; set; }
        public string? PosrouteId { get; set; }
        public string? PosenterpriseId { get; set; }
        public bool? IsRetailerLevel { get; set; }
        public int? ClientEnterprisesId { get; set; }

        public virtual ClientEnterprise? ClientEnterprises { get; set; }
    }
}
