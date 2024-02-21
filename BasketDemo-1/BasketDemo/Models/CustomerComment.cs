using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class CustomerComment
    {
        public int CommentId { get; set; }
        public string? CommentDescription { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
