using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int Identity { get; set; }
    }
}
