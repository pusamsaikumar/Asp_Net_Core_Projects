using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class S3Model
    {
        public string Name { get; set; }    
        public string PresignedUrl { get; set; }
    }
}
