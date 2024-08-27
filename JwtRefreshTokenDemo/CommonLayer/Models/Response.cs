using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class Response
    {
        public int StatusCode { get; set; } 
        public string StatusMessage { get; set; }
        public LoginModel LoginModel { get; set; }
        public RegisterModel RegisterModel { get; set; }    

    }
}
