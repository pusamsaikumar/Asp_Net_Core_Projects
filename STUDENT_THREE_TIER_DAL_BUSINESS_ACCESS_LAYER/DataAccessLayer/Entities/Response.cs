using CommonLayer.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Response
    {
       public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Student> ListStudent { get; set; }
        public AppSettings appsettings { get;}
        public Student Student { get; set; }

        public TokenModel Token { get; set; }

        public LoginModel Login { get; set; }
        public RegisterModel Register { get; set; }
        
    }
}
