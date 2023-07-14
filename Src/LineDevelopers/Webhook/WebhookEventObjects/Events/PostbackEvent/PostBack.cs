using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class PostBack
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("params")]
        public PostBackParam Params { get; set; }
    }
}
