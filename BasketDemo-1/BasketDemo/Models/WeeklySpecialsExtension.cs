using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class WeeklySpecialsExtension
    {
        public int ExtensionId { get; set; }
        public int? NewsId { get; set; }
        public string? SpecialPrice { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public int? CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }

        public virtual Ssnews? News { get; set; }
    }
}
