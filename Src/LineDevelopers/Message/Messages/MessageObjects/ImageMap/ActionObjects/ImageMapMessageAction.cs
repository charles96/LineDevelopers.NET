using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ImageMapMessageAction), "message")]
    public class ImageMapMessageAction : IImageMapAction
    {
        public ImageMapMessageAction() { }

        [SetsRequiredMembers]
        public ImageMapMessageAction(string text,
                                     ImageMapArea area,
                                     string? label = null) 
        { 
            this.Text = text;
            this.Area = area;
            this.Label = label;
        }

        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        [JsonPropertyName("text")]
        public required string Text { get; set; }

        [JsonPropertyName("area")]
        public required ImageMapArea Area { get; set; }
    }
}
