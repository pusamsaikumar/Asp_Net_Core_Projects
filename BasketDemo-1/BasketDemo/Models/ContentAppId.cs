using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ContentAppId
    {
        public int Id { get; set; }
        public string? AppId { get; set; }
        public string? InstanceName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ServiceNameId { get; set; }
    }
}
