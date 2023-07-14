using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class ThingsActionResult
    {
        [JsonPropertyName("type")]
        public ThingsActionResultType Type { get; set; }

        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Data { get; set; }
    }
}
