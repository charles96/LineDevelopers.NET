using System.Text.Json.Serialization;

namespace Line.Message
{
    public class GroupChatMemberProfile
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
        
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("pictureUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PictureUrl { get; set; }
    }
}
