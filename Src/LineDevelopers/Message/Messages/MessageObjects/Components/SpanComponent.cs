using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(SpanComponent), "span")]
    public class SpanComponent : IComponent
    {
        public SpanComponent() { }

        public SpanComponent(string? text = null,
                             string? color = null,
                             string? size = null,
                             WeightType? weight = null,
                             TextStyleType? style = null,
                             DecorationType? decoration = null)
        {
            Text = text;
            Color = color;
            Size = size;
            Weight = weight;
            Style = style;
            Decoration = decoration;
        }

        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Text { get; set; }

        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Color { get; set; }

        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Size { get; set; }

        [JsonPropertyName("weight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WeightType? Weight { get; set; }

        [JsonPropertyName("style")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextStyleType? Style { get; set; }

        [JsonPropertyName("decoration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DecorationType? Decoration { get; set; }
    }
}
