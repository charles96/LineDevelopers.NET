using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(SeparatorComponent), "separator")]
    public class SeparatorComponent : IComponent
    {
        public SeparatorComponent() { }

        public SeparatorComponent(string? margin = null,
                                  string? color = null)
        {
            Margin = margin;
            Color = color;
        }

        [JsonPropertyName("margin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Margin { get; set; }

        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Color { get; set; }
    }
}
