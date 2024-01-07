using Newtonsoft.Json;

namespace Etrel_Configurator.Models
{
    public class ChargerSystemInformation
    {
        [JsonProperty("model")]
        public required string Model { get; set; }

        [JsonProperty("serialNumber")]
        public required string SerialNumber { get; set; }

        [JsonProperty("operationsVersion")]
        public required string OperationsVersion { get; set; }

        [JsonProperty("osVersion")]
        public required string OsVersion { get; set; }
    }
}
