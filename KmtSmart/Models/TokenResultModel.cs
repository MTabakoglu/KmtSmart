using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Models
{
    public class TokenResultModel
    {
        public int UserIdentifier { get; set; }
        public string Name { get; set; }
        public DateTime Expiration { get; set; }
        public List<string> Roles { get; set; }
    }
}
