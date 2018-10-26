using Newtonsoft.Json;
using System;

namespace APIFP.Model
{
    public partial class Aiport
    {
        [JsonProperty("ICAO")]
        public string Icao { get; set; }

        [JsonProperty("IATA")]
        public string Iata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        [JsonProperty("elevation")]
        public long? Elevation { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("magneticVariation")]
        public double MagneticVariation { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }

        [JsonProperty("times")]
        public Times Times { get; set; }

        [JsonProperty("runwayCount")]
        public long? RunwayCount { get; set; }

        [JsonProperty("runways")]
        public Runway[] Runways { get; set; }

        [JsonProperty("frequencies")]
        public Frequency[] Frequencies { get; set; }

        [JsonProperty("weather")]
        public Weather Weather { get; set; }
    }

    public class Frequency
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("frequency")]
        public long? FrequencyFrequency { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Runway
    {
        [JsonProperty("ident")]
        public string Ident { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("length")]
        public double Length { get; set; }

        [JsonProperty("bearing")]
        public double Bearing { get; set; }

        [JsonProperty("surface")]
        public string Surface { get; set; }

        [JsonProperty("thresholdOffset")]
        public double ThresholdOffset { get; set; }

        [JsonProperty("overrunLength")]
        public double OverrunLength { get; set; }

        [JsonProperty("ends")]
        public End[] Ends { get; set; }

        [JsonProperty("navaids")]
        public Navaid[] Navaids { get; set; }
    }

    public class End
    {
        [JsonProperty("ident")]
        public string Ident { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public class Navaid
    {
        [JsonProperty("ident")]
        public string Ident { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("airport")]
        public string Airport { get; set; }

        [JsonProperty("runway")]
        public string Runway { get; set; }

        [JsonProperty("frequency")]
        public long? Frequency { get; set; }

        [JsonProperty("slope")]
        public double? Slope { get; set; }

        [JsonProperty("bearing")]
        public double? Bearing { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("elevation")]
        public long? Elevation { get; set; }

        [JsonProperty("range")]
        public long? Range { get; set; }
    }

    public class Times
    {
        [JsonProperty("sunrise")]
        public DateTimeOffset Sunrise { get; set; }

        [JsonProperty("sunset")]
        public DateTimeOffset Sunset { get; set; }

        [JsonProperty("dawn")]
        public DateTimeOffset Dawn { get; set; }

        [JsonProperty("dusk")]
        public DateTimeOffset Dusk { get; set; }
    }

    public class Timezone
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("offset")]
        public long? Offset { get; set; }
    }

    public class Weather
    {
        [JsonProperty("METAR")]
        public string Metar { get; set; }

        [JsonProperty("TAF")]
        public object Taf { get; set; }
    }

    public partial class Aiport
    {
        public static Aiport FromJson(string json) => JsonConvert.DeserializeObject<Aiport>(json);
    }
}
