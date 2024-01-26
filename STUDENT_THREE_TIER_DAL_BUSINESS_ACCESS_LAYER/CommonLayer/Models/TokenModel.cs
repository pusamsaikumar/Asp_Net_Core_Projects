using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class TokenModel
    {
        public string AccessToken { get; set;}
        public string RefreshToken {  get; set;}

        public DateTime ExpireRefreshTokenTime { get; set;}
    }
}
