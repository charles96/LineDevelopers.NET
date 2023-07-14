using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(VideoComponent), "video")]
    public class VideoComponent : IComponent
    {
        public VideoComponent() { }

        [SetsRequiredMembers]
        public VideoComponent(string url,
                              string previewUrl,
                              IComponent altContent,
                              string? aspectRatio = null,
                              UriAction? action = null)
        {
            Url = url;
            PreviewUrl = previewUrl;
            AltContent = altContent;
            AspectRatio = aspectRatio;
            Action = action;
        }

        [JsonPropertyName("url")]
        public required string Url { get; set; }

        [JsonPropertyName("previewUrl")]
        public required string PreviewUrl { get; set; }

        /// <summary>
        /// Alternative content. 
        /// The alternative content will be displayed on the screen of a user device that is using a version of LINE that doesn't support the video component. 
        /// Specify a box or an image.
        /// </summary>
        [JsonPropertyName("altContent")]
        public required IComponent AltContent { get; set; }

        [JsonPropertyName("aspectRatio")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AspectRatio { get; set; }

        [JsonPropertyName("action")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UriAction? Action { get; set; }
    }
}
