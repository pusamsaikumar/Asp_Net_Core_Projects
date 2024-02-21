using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class AspnetSchemaVersion
    {
        public string Feature { get; set; } = null!;
        public string CompatibleSchemaVersion { get; set; } = null!;
        public bool IsCurrentVersion { get; set; }
    }
}
