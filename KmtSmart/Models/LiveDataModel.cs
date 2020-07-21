using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KmtSmart.Models
{
    public class LiveDataModel
    {
        //[JsonPropertyName("id")]
        //public int Id { get; set; }
        [JsonPropertyName("did")]
        public int DeviceId { get; set; }
        [JsonPropertyName("ic")]
        public bool IsCutting { get; set; }
        [JsonPropertyName("cd")]
        public CuttingData CuttingData { get; set; }
        [JsonPropertyName("dt")]
        public DateTime TimeToAdd { get; set; }

    }
    public class CuttingData
    {
        public CuttingData()
        {
            Alarms = new List<string>();
        }
        [JsonPropertyName("ct")]
        public string CuttingType { get; set; }

        [JsonPropertyName("wn")]
        public string WorkOrderName { get; set; }
        [JsonPropertyName("wi")]
        public int WorkorderCuttingId { get; set; }

        [JsonPropertyName("cs")]
        public float CuttingSet { get; set; }
        [JsonPropertyName("cr")]
        public float CuttingReal { get; set; }

        [JsonPropertyName("mp")]
        public float MainMotorPower { get; set; }
        [JsonPropertyName("sp")]
        public float ServoPower { get; set; }

        [JsonPropertyName("fp")]
        public float FrontPosition { get; set; }
        [JsonPropertyName("rp")]
        public float RearPosition { get; set; }

        [JsonPropertyName("acs")]
        public float ActiveCrossSection { get; set; }
        [JsonPropertyName("bs")]
        public float BladeSpeed { get; set; }
        [JsonPropertyName("ss")]
        public float ServoSpeed { get; set; }
        [JsonPropertyName("bp")]
        public float BodyPosition { get; set; }

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

        [JsonPropertyName("alrt")]
        public List<string> Alarms { get; set; }

    }
}
