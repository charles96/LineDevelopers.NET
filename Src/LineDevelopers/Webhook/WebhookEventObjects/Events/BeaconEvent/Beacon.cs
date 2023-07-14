using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class Beacon
    {
        [JsonPropertyName("hwid")]
        public string hwid {  get; set; }

        [JsonPropertyName("type")]
        public BeaconEventType Type { get; set; }

        [JsonPropertyName("dm")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Dm { get; set; }
    }
}
