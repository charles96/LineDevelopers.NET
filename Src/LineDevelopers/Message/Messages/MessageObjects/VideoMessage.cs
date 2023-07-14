using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(VideoMessage), "video")]
    public class VideoMessage : IMessage
    {
        public VideoMessage() { }

        [SetsRequiredMembers]
        public VideoMessage(string originalContentUrl,
                            string previewImageUrl,
                            string? trackingId = null,
                            QuickReply? quickReply = null)
        {
            QuickReply = quickReply;
            OriginalContentUrl = originalContentUrl;
            PreviewImageUrl = previewImageUrl;
            TrackingId = trackingId;
        }

        [JsonPropertyName("quickReply")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QuickReply? QuickReply { get; set; }

        [JsonPropertyName("originalContentUrl")]
        public required string OriginalContentUrl { get; set; }

        [JsonPropertyName("previewImageUrl")]
        public required string PreviewImageUrl { get; set; }

        [JsonPropertyName("trackingId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TrackingId { get; set; }
    }
}
