using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class ContentProvider
    {
        [JsonPropertyName("type")]
        public ContentProviderType Type { get; set; }

        [JsonPropertyName("originalContentUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OriginalContentUrl { get; set; }

        [JsonPropertyName("previewImageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PreviewImageUrl { get; set; }
    }
}
