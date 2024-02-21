using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class NewsCategory
    {
        public int NewsCategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool? IsActive { get; set; }
    }
}
