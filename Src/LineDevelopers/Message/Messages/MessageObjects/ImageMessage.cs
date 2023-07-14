using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ImageMessage), "image")]
    public class ImageMessage : IMessage
    {
        public ImageMessage() { }

        [SetsRequiredMembers]
        public ImageMessage(string originalContentUrl,
                            string previewImageUrl,
                            QuickReply? quickReply = null)
        { 
            this.OriginalContentUrl = originalContentUrl;
            this.PreviewImageUrl = previewImageUrl;
            this.QuickReply = quickReply;
        }

        [JsonPropertyName("quickReply")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QuickReply? QuickReply { get; set; }

        [JsonPropertyName("originalContentUrl")]
        public required string OriginalContentUrl { get; set; }

        [JsonPropertyName("previewImageUrl")]
        public required string PreviewImageUrl { get; set; }
    }
}
