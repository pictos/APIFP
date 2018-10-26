using Newtonsoft.Json;

namespace APIFP.Model
{
    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("gravatarHash")]
        public string GravatarHash { get; set; }

        [JsonProperty("location")]
        public object Location { get; set; }
    }
}
