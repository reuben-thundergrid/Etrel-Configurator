using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrel_Configurator.Models
{
    internal class ChargerConfig
    {
        [JsonProperty("configVersion")]
        public int ConfigVersion { get; set; }
        [JsonProperty("apiEndpoints")]
        public Dictionary<string, Dictionary<string, string>> ApiEndpoints { get; set; }
    }
}
