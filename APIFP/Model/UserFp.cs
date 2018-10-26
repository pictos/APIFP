using Newtonsoft.Json;
using System;

namespace APIFP.Model
{
    public partial class UserFp
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("fromICAO")]
        public string FromIcao { get; set; }

        [JsonProperty("toICAO")]
        public string ToIcao { get; set; }

        [JsonProperty("fromName")]
        public string FromName { get; set; }

        [JsonProperty("toName")]
        public string ToName { get; set; }

        [JsonProperty("flightNumber")]
        public object FlightNumber { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("maxAltitude")]
        public long MaxAltitude { get; set; }

        [JsonProperty("waypoints")]
        public long Waypoints { get; set; }

        [JsonProperty("likes")]
        public long Likes { get; set; }

        [JsonProperty("downloads")]
        public long Downloads { get; set; }

        [JsonProperty("popularity")]
        public long Popularity { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("encodedPolyline")]
        public string EncodedPolyline { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }


    public partial class UserFp
    {
        public static UserFp[] FromJson(string json) => JsonConvert.DeserializeObject<UserFp[]>(json);
    }

}
