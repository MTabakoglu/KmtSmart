using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Models
{
    public class DeviceModel
    {
       
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceKey { get; set; }
        public DateTime TimeToAdd { get; set; }
        public bool Status { get; set; }
    }
}
