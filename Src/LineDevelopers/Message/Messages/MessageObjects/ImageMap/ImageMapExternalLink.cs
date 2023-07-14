using System.Text.Json.Serialization;

namespace Line.Message
{
    public class ImageMapExternalLink
    {
        public ImageMapExternalLink() { }

        public ImageMapExternalLink(string? linkUri = null,
                                    string? label = null)
        {
            LinkUri = linkUri;
            Label = label;
        }

        /// <summary>
        /// Webpage URL. Called when the label displayed after the video is tapped.
        /// Max character limit: 1000
        /// The available schemes are http, https, line, and tel.For more information about the LINE URL scheme, see Using LINE features with the LINE URL scheme.
        /// The URL should be percent-encoded using UTF-8. For more information, see About the encoding of a URL specified in a request body property.
        /// </summary>
        [JsonPropertyName("linkUri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LinkUri { get; set; }

        /// <summary>
        /// Label. Displayed after the video is finished.
        /// Max character limit: 30
        /// </summary>
        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }
    }
}
