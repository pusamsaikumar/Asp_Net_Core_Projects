using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<State> States { get; set; }
    }
}
