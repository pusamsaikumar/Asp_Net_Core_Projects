using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class NewsItem
    {
        public short NewsItemId { get; set; }
        public short NewsItemCategoryId { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string Title { get; set; } = null!;
        public string Details { get; set; } = null!;
        public string? Image { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public short CreatedUser { get; set; }
        public short UpdatedUser { get; set; }
    }
}
