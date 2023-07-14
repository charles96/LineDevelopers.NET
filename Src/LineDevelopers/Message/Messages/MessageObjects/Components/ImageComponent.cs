using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ImageComponent), "image")]
    public class ImageComponent : IComponent
    {
        public ImageComponent() { }

        [SetsRequiredMembers]
        public ImageComponent(string url,
                              int? flex = null,
                              string? margin = null,
                              PositionType? position = null,
                              string? offsetTop = null,
                              string? offsetBottom = null,
                              string? offsetStart = null,
                              string? offsetEnd = null,
                              HorizontalDirectionType? align = null,
                              VerticalDirectionType? gravity = null,
                              string? size = null,
                              string? aspectRatio = null,
                              AspectModeType? aspectMode = null,
                              string? backgroundColor = null,
                              IAction? action = null,
                              bool? animated = null)
        {
            Url = url;
            Flex = flex;
            Margin = margin;
            Position = position;
            OffsetTop = offsetTop;
            OffsetBottom = offsetBottom;
            OffsetStart = offsetStart;
            OffsetEnd = offsetEnd;
            Align = align;
            Gravity = gravity;
            Size = size;
            AspectRatio = aspectRatio;
            AspectMode = aspectMode;
            BackgroundColor = backgroundColor;
            Action = action;
            Animated = animated;
        }

        [JsonPropertyName("url")]
        public required string Url { get; set; }

        [JsonPropertyName("flex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Flex { get; set; }

        [JsonPropertyName("margin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Margin { get; set; }

        [JsonPropertyName("position")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PositionType? Position { get; set; }

        [JsonPropertyName("offsetTop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OffsetTop { get; set; }

        [JsonPropertyName("offsetBottom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OffsetBottom { get; set; }

        [JsonPropertyName("offsetStart")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OffsetStart { get; set; }

        [JsonPropertyName("offsetEnd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OffsetEnd { get; set; }

        [JsonPropertyName("align")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HorizontalDirectionType? Align { get; set; }

        [JsonPropertyName("gravity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VerticalDirectionType? Gravity { get; set; }

        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Size { get; set; }

        [JsonPropertyName("aspectRatio")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AspectRatio { get; set; }

        [JsonPropertyName("aspectMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AspectModeType? AspectMode { get; set; }

        [JsonPropertyName("backgroundColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BackgroundColor { get; set; }

        [JsonPropertyName("action")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IAction? Action { get; set; }

        [JsonPropertyName("animated")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Animated { get; set; }

    }
}
