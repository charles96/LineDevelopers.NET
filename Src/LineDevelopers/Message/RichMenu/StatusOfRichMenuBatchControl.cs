using System.Text.Json.Serialization;

namespace Line.Message
{
    public class StatusOfRichMenuBatchControl
    {
        [JsonPropertyName("phase")]
        public BatchControlStatus Phase { get; set; }

        [JsonPropertyName("acceptedTime")]
        public string AcceptedTime { get; set; }

        [JsonPropertyName("completedTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CompletedTime { get; set; }
    }
}
