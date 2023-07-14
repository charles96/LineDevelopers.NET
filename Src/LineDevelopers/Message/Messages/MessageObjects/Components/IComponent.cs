using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(BoxComponent), "box")]
    [JsonDerivedType(typeof(ButtonComponent), "button")]
    [JsonDerivedType(typeof(ImageComponent), "image")]
    [JsonDerivedType(typeof(VideoComponent), "video")]
    [JsonDerivedType(typeof(IconComponent), "icon")]
    [JsonDerivedType(typeof(TextComponent), "text")]
    [JsonDerivedType(typeof(SpanComponent), "span")]
    [JsonDerivedType(typeof(SeparatorComponent), "separator")]
    [JsonDerivedType(typeof(FillerComponent), "filler")]
    public interface IComponent
    {
    }
}
