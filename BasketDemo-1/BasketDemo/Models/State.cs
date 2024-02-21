using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class State
    {
        public long StateId { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;
    }
}
