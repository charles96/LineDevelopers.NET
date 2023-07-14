using System.Text.Json.Serialization;

namespace Line.Message
{
    public class TargetLimitForSendingMessagesThisMonth
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Value { get; set; }
    }
}
