using System.Text.Json.Serialization;

namespace Line.Message
{
    public class MultiPersonChatMemberProfile
    {
        [JsonPropertyName("displayName")]
        public string displayName { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("pictureUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PictureUrl { get; set; }
    }
}
