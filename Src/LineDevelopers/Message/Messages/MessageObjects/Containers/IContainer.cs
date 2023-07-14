using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(Bubble), "bubble")]
    [JsonDerivedType(typeof(Carousel), "carousel")]
    public interface IContainer
    {
    }
}
