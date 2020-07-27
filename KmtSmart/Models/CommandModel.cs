using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Models
{
    public class CommandModel
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Parameters> Parameters { get; set; }
    }

    public class Parameters
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

