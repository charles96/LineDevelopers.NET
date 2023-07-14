using System.Text.Json.Serialization;

namespace Line.Message
{
    public class NumberOfSentMessages
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("success")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? Success { get; set; }
    }
}
