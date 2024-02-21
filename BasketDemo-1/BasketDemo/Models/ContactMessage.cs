using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ContactMessage
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
    }
}
