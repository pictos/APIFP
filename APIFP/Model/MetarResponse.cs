using Newtonsoft.Json;

namespace APIFP.Model
{

    public partial class MetarResponse
    {
        [JsonProperty("METAR")]
        public string Metar { get; set; }

        [JsonProperty("TAF")]
        public string Taf { get; set; }
    }

    public partial class MetarResponse
    {
        public static MetarResponse FromJson(string json) => JsonConvert.DeserializeObject<MetarResponse>(json);
    }

}
