using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ContactU
    {
        public int ContactUsId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public string? Team { get; set; }
        public int? NumberOfVenues { get; set; }
        public string? Pos { get; set; }
        public string? HowDidYouKnow { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
