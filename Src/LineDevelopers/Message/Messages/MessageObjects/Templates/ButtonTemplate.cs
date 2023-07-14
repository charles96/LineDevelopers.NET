using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ButtonTemplate), "buttons")]
    public class ButtonTemplate : ITemplate
    {
        public ButtonTemplate() { }

        [SetsRequiredMembers]
        public ButtonTemplate(string text, 
                              IList<IAction> actions,
                              IAction? defaultAction = null,
                              string? title = null,
                              string? thumbnailImageUrl = null,
                              string? imageAspectRatio = null,
                              string? imageSize = null,
                              string? imageBackgroundColor = null)
        {
            ThumbnailImageUrl = thumbnailImageUrl;
            ImageAspectRatio = imageAspectRatio;
            ImageSize = imageSize;
            ImageBackgroundColor = imageBackgroundColor;
            Title = title;
            Text = text;
            DefaultAction = defaultAction;
            Actions = actions;
        }

        [JsonPropertyName("thumbnailImageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ThumbnailImageUrl { get; set; }

        [JsonPropertyName("imageAspectRatio")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageAspectRatio { get; set; }

        /// <summary>
        /// Size of the image. One of:
        /// cover: The image fills the entire image area.Parts of the image that do not fit in the area are not displayed.
        /// contain: The entire image is displayed in the image area.A background is displayed in the unused areas to the left and right of vertical images and in the areas above and below horizontal images.
        /// Default: cover
        /// </summary>
        [JsonPropertyName("imageSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageSize { get; set; }

        /// <summary>
        /// Background color of the image. Specify a RGB color value. 
        /// Default: #FFFFFF (white)
        /// </summary>
        [JsonPropertyName("imageBackgroundColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageBackgroundColor { get; set; }

        /// <summary>
        /// Title
        /// Max character limit: 40
        /// </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }

        /// <summary>
        /// Message text
        /// Max character limit: 160 (no image or title)
        /// Max character limit: 60 (message with an image or title)
        /// </summary>
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        /// <summary>
        /// Action when image, title or text area is tapped.
        /// </summary>
        [JsonPropertyName("defaultAction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IAction? DefaultAction { get; set; }

        /// <summary>
        /// Action when tapped
        /// Max objects: 4
        /// </summary>
        [JsonPropertyName("actions")]
        public required IList<IAction> Actions { get; set; }
    }
}
