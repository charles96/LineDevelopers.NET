using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ButtonComponent), "button")]
    public class ButtonComponent : IComponent
    {
        public ButtonComponent() { }

        [SetsRequiredMembers]
        public ButtonComponent(IAction action,
                               int? flex = null,
                               string? margin = null,
                               PositionType? position = null,
                               string? offsetTop = null,
                               string? offsetBottom = null,
                               string? offsetStart = null,
                               string? offsetEnd = null,
                               string? height = null,
                               ButtonStyleType? style = null,
                               string? color = null,
                               VerticalDirectionType? gravity = null,
                               string? adjustMode = null)
        {
            Action = action;
            Flex = flex;
            Margin = margin;
            Position = position;
            OffsetTop = offsetTop;
            OffsetBottom = offsetBottom;
            OffsetStart = offsetStart;
            OffsetEnd = offsetEnd;
            Height = height;
            Style = style;
            Color = color;
            Gravity = gravity;
            AdjustMode = adjustMode;
        }

        [JsonPropertyName("action")]
        public required IAction Action { get; set; }
        
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

        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Height { get; set; }

        [JsonPropertyName("style")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ButtonStyleType? Style { get; set; }

        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Color { get; set; }
                
        [JsonPropertyName("gravity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VerticalDirectionType? Gravity { get; set; }

        [JsonPropertyName("adjustMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AdjustMode { get; set; }

    }
}
