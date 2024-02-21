using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class QualifyingProduct
    {
        public int Id { get; set; }
        public string? DirectiveId { get; set; }
        public string? Name { get; set; }
        public string? Reference { get; set; }
        public string? UnitPrice { get; set; }
        public string? Type { get; set; }
    }
}
