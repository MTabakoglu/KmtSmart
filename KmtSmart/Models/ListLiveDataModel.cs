using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace KmtSmart.Models
{
    public class ListLiveDataModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("did")]
        public int DeviceId { get; set; }


        [JsonPropertyName("ct")]
        public string CuttingType { get; set; }

        [JsonPropertyName("mt")]
        public string MaterialType { get; set; }

        [JsonPropertyName("geo")]
        public string Geometry { get; set; }
        [JsonPropertyName("wn")]
        public string WorkOrderName { get; set; }
        [JsonPropertyName("wi")]
        public int WorkorderCuttingId { get; set; }

        [JsonPropertyName("mp")]
        public float MainMotorPower { get; set; }
        [JsonPropertyName("spo")]
        public float ServoPower { get; set; }

        [JsonPropertyName("cy")]
        public float Cycle { get; set; }
        [JsonPropertyName("sp")]
        public float Speed { get; set; }

        [JsonPropertyName("cm")]
        public float CycleMultiplier { get; set; }
        [JsonPropertyName("sm")]
        public float SpeedMultiplier { get; set; }

        [JsonPropertyName("cc")]
        public float CurveCut { get; set; }

        [JsonPropertyName("qa")]
        public int QuantityAll { get; set; }
        [JsonPropertyName("ac")]
        public int AmountCutting { get; set; }

        [JsonPropertyName("rt")]
        public int RemainingTime { get; set; }
        [JsonPropertyName("et")]
        public int ElapsedTime { get; set; }
        [JsonPropertyName("tt")]
        public int TotalTime { get; set; }


        [JsonPropertyName("alarm")]
        public string Alarms { get; set; }

        [JsonPropertyName("dt")]
        public DateTime TimeToAdd { get; set; }
    }
}
