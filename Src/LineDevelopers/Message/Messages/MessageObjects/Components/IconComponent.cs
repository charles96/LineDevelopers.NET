using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(IconComponent), "icon")]
    public class IconComponent : IComponent
    {
        public IconComponent() { }

        [SetsRequiredMembers]
        public IconComponent(string url,
                             string? margin = null,
                             PositionType? position = null,
                             string? offsetTop = null,
                             string? offsetBottom = null,
                             string? offsetStart = null,
                             string? offsetEnd = null,
                             string? size = null,
                             string? aspectRatio = null)
        {
            Url = url;
            Margin = margin;
            Position = position;
            OffsetTop = offsetTop;
            OffsetBottom = offsetBottom;
            OffsetStart = offsetStart;
            OffsetEnd = offsetEnd;
            Size = size;
            AspectRatio = aspectRatio;
        }

        [JsonPropertyName("url")]
        public required string Url { get; set; }

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

        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Size { get; set; }

        [JsonPropertyName("aspectRatio")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AspectRatio { get; set; }
    }
}
