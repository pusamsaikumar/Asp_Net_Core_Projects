using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class JWT
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public int TokenValidityInMinutes { get; set; }
        public int RefreshTokenValidityInMinutes { get; set; }
    }
}
