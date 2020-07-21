using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Models
{
    public class MachineModel
    {
        public int MachineId { get; set; }
        public int UserId { get; set; }
        public int ModelId { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }

    }
}
