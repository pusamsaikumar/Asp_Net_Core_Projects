using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class WeeklyAddPdf
    {
        public int WeeklyAdPdfId { get; set; }
        public int StoreId { get; set; }
        public int PageNumber { get; set; }
        public DateTime ValidFromDate { get; set; }
        public DateTime Expireson { get; set; }
        public string? PdfFileName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
