using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ButtonTemplate), "buttons")]
    [JsonDerivedType(typeof(ConfirmTemplate), "confirm")]
    [JsonDerivedType(typeof(CarouselTemplate), "carousel")]
    [JsonDerivedType(typeof(ImageCarouselTemplate), "image_carousel")]
    public interface ITemplate
    {
    }
}
