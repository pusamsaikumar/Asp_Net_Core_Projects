using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Exception
    {
        public int ExceptionId { get; set; }
        public int? CodeModuleId { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? ExceptionDetails { get; set; }
        public DateTime? ExceptionDate { get; set; }
    }
}
