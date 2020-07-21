using System;
using System.Collections.Generic;
using System.Text;

namespace KmtSmart.Models
{
    public class WorkOrderModel
    {
        public int DeviceId { get; set; }
        public int WorkOrderId { get; set; }
        public string WorkOrderName { get; set; }
        public string Status { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime? CutDateTime { get; set; }
        public List<Cutting> CuttingList { get; set; }
    }

    public class Cutting 
    {
        public int CuttingId { get; set; }
        public int WorkOrderId { get; set; }
        public double CuttingLenght { get; set; }
        public int TotalPiece { get; set; }
        public int Packet { get; set; }
        public float Cycle { get; set; }
        public float Speed { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

    }
}
