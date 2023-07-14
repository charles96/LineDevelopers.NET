using System.Text.Json.Serialization;

namespace Line.Message
{
    public class BotInformation
    {
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("basicId")]
        public string BasicId { get; set; }

        [JsonPropertyName("premiumId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PremiumId { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("pictureUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PictureUrl { get; set; }

        [JsonPropertyName("chatMode")]
        public string ChatMode { get; set; }

        [JsonPropertyName("markAsReadMode")]
        public string MarkAsReadMode { get; set; }
    }
}
