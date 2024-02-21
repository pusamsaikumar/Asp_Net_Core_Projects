using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class DataImport
    {
        public int DataImportId { get; set; }
        public Guid DataImportUniqueId { get; set; }
        public string? FileName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public int? CustomerId { get; set; }
    }
}
