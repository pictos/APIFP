using Newtonsoft.Json;

namespace APIFP.Model
{

    public partial class ErrorMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public Error[] Errors { get; set; }
    }

    public partial class Error
    {
        [JsonProperty("param")]
        public string Param { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class ErrorMessage
    {
        public static ErrorMessage FromJson(string json) => JsonConvert.DeserializeObject<ErrorMessage>(json);
    }
}
