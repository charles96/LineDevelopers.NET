using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(TextComponent), "text")]
    public class TextComponent : IComponent
    {
        public TextComponent() { }

        public TextComponent(string? text = null,
                             IList<SpanComponent>? contents = null,
                             string? adjustMode = null,
                             int? flex = null,
                             string? margin = null,
                             PositionType? position = null,
                             string? offsetTop = null,
                             string? offsetBottom = null,
                             string? offsetStart = null,
                             string? offsetEnd = null,
                             string? size = null,
                             HorizontalDirectionType? align = null,
                             VerticalDirectionType? gravity = null,
                             bool? wrap = null,
                             string? lineSpacing = null,
                             int? maxLines = null,
                             WeightType? weight = null,
                             string? color = null,
                             IAction? action = null,
                             TextStyleType? style = null,
                             DecorationType? decoration = null)
        {
            Text = text;
            Contents = contents;
            AdjustMode = adjustMode;
            Flex = flex;
            Margin = margin;
            Position = position;
            OffsetTop = offsetTop;
            OffsetBottom = offsetBottom;
            OffsetStart = offsetStart;
            OffsetEnd = offsetEnd;
            Size = size;
            Align = align;
            Gravity = gravity;
            Wrap = wrap;
            LineSpacing = lineSpacing;
            MaxLines = maxLines;
            Weight = weight;
            Color = color;
            Action = action;
            Style = style;
            Decoration = decoration;
        }

        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Text { get; set; }

        [JsonPropertyName("contents")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<SpanComponent>? Contents { get; set; }

        [JsonPropertyName("adjustMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AdjustMode { get; set; }

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

        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Size { get; set; }

        [JsonPropertyName("align")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HorizontalDirectionType? Align { get; set; }

        [JsonPropertyName("gravity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VerticalDirectionType? Gravity { get; set; }

        [JsonPropertyName("wrap")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Wrap { get; set; }

        [JsonPropertyName("lineSpacing")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LineSpacing { get; set; }

        [JsonPropertyName("maxLines")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxLines { get; set; }
        
        [JsonPropertyName("weight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WeightType? Weight { get; set; }

        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Color { get; set; }

        [JsonPropertyName("action")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IAction? Action { get; set; }

        [JsonPropertyName("style")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextStyleType? Style { get; set; }

        [JsonPropertyName("decoration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DecorationType? Decoration { get; set; }
    }
}
