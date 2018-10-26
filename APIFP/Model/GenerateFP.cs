using Newtonsoft.Json;

namespace APIFP.Model
{
    public class GenerateFP
    {
        [JsonProperty("fromICAO")]
        public string FromIcao { get; set; }

        [JsonProperty("toICAO")]
        public string ToIcao { get; set; }

        [JsonProperty("cruiseAlt")]
        public string MaxAlt { get; set; }

        [JsonProperty("cruiseSpeed")]
        public string CruiseSpeed { get; set; }
    }
}
