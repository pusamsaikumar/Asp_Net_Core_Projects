using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class PageItem
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public string? RecipeName { get; set; }
        public string? ItemPrice { get; set; }
        public string? DealDetails { get; set; }
        public int? Width { get; set; }
        public string? DepartmentId { get; set; }
        public int? RecipeId { get; set; }
        public string? RecipeImage { get; set; }
        public string? ItemImage { get; set; }
        public int? Height { get; set; }
        public long? AdItemId { get; set; }
        public string? RecipeMoreKeyword { get; set; }
        public string? ItemName { get; set; }
        public int? DepartmentIdInt { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }

        public virtual Page? PidNavigation { get; set; }
    }
}
