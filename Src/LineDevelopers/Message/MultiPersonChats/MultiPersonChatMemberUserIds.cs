using System.Text.Json.Serialization;

namespace Line.Message
{
    public class MultiPersonChatMemberUserIds
    {
        [JsonPropertyName("memberIds")]
        public string[] MemberIds { get; set;}

        [JsonPropertyName("next")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Next { get; set; }
    }
}
