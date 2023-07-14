using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class Mentionee
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        [JsonPropertyName("type")]
        public MentioneeType Type { get; set; }

        [JsonPropertyName("userId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UserId { get; set; }
    }
}
