using System.Text.Json.Serialization;

namespace Line.Message
{
    public class ImageMapVideo
    {
        public ImageMapVideo() { }

        public ImageMapVideo(string? originalContentUrl = null,
                             string? previewImageUrl = null,
                             ImageMapVideoArea? area = null,
                             ImageMapExternalLink? externalLink = null)
        {
            OriginalContentUrl = originalContentUrl;
            PreviewImageUrl = previewImageUrl;
            Area = area;
            ExternalLink = externalLink;
        }

        /// <summary>
        /// URL of the video file (Max character limit: 2000)
        /// HTTPS over TLS 1.2 or later
        /// mp4
        /// Max file size: 200 MB
        /// The URL should be percent-encoded using UTF-8. For more information, see About the encoding of a URL specified in a request body property.
        /// </summary>
        [JsonPropertyName("originalContentUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OriginalContentUrl { get; set; }

        /// <summary>
        /// URL of the preview image (Max character limit: 2000)
        /// HTTPS over TLS 1.2 or later
        /// JPEG or PNG
        /// Max file size: 1 MB
        /// The URL should be percent-encoded using UTF-8. For more information, see About the encoding of a URL specified in a request body property.
        /// </summary>
        [JsonPropertyName("previewImageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PreviewImageUrl { get; set; }

        [JsonPropertyName("area")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageMapVideoArea? Area { get; set; }

        [JsonPropertyName("externalLink")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageMapExternalLink? ExternalLink { get; set; }
    }
}
