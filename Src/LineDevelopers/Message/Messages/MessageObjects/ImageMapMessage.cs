using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ImageMapMessage), "imagemap")]
    public class ImageMapMessage : IMessage
    {
        public ImageMapMessage() { }

        [SetsRequiredMembers]
        public ImageMapMessage(string baseUrl,
                               string altText,
                               ImageMapBaseSize baseSize,
                               IList<IImageMapAction> actions,
                               ImageMapVideo? video = null,
                               QuickReply? quickReply = null)
        {
            QuickReply = quickReply;
            BaseUrl = baseUrl;
            AltText = altText;
            BaseSize = baseSize;
            Video = video;
            Actions = actions;
        }

        [JsonPropertyName("quickReply")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QuickReply? QuickReply { get; set; }

        /// <summary>
        /// Base URL of the image
        /// Max character limit: 2000
        /// </summary>
        [JsonPropertyName("baseUrl")]
        public required string BaseUrl { get; set; }

        /// <summary>
        /// Alternative text. When a user receives a message, 
        /// it will appear as an alternative to the image in the notification or chat list of their device.
        /// Max character limit: 400
        /// </summary>
        [JsonPropertyName("altText")]
        public required string AltText { get; set; }

        /// <summary>
        /// Width of base image in pixels. Set to 1040.
        /// </summary>
        [JsonPropertyName("baseSize")]
        public required ImageMapBaseSize BaseSize { get; set; }

        [JsonPropertyName("video")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageMapVideo? Video { get; set; }

        /// <summary>
        /// Action when tapped
        /// Max: 50
        /// </summary>
        [JsonPropertyName("actions")]
        public required IList<IImageMapAction> Actions { get; set; }
    }
}
