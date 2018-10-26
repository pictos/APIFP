using Newtonsoft.Json;
using System;

namespace APIFP.Model
{
    public partial class Fpid : GenerateResponseFP
    {

        [JsonProperty("route")]
        public Route Route { get; set; }

        [JsonProperty("likes")]
        public long Likes { get; set; }
    }

    public partial class Route
    {
        [JsonProperty("nodes")]
        public Node[] Nodes { get; set; }
    }

    public partial class Node
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ident")]
        public string Ident { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("alt")]
        public long Alt { get; set; }

        [JsonProperty("via")]
        public object Via { get; set; }
    }
    public partial class Fpid
    {
        public static Fpid FromJson(string json) => JsonConvert.DeserializeObject<Fpid>(json);
    }
}
