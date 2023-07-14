using System.Text.Json.Serialization;

namespace Line.Message
{
    public class Followers 
    {
        [JsonPropertyName("userIds")]
        public IList<string> UserIds { get; set; }

        [JsonPropertyName("next")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Next { get; set; }

        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }
    }
}
