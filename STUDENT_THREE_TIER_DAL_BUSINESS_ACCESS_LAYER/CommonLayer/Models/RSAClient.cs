using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class RSAClient
    {
       public int RSAClientId { get; set; }
        public string RSAClientName { get; set; }
        public string Stores { get; set; }
    }
   public class RSAClientData
    {
        public List<RSAClient>? rSAClients { get; set; }
    }

}
