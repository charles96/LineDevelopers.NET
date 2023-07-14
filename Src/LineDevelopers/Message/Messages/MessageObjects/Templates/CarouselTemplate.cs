using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(CarouselTemplate), "carousel")]
    public class CarouselTemplate : ITemplate
    {
        public CarouselTemplate() { }
                
        [SetsRequiredMembers]
        public CarouselTemplate(IList<CarouselColumnObject> columns,
                                string? imageAspectRatio = null,
                                string? imageSize = null)
        {
            Columns = columns;
            ImageAspectRatio = imageAspectRatio;
            ImageSize = imageSize;
        }

        [JsonPropertyName("columns")]
        public required IList<CarouselColumnObject> Columns { get; set; }

        [JsonPropertyName("imageAspectRatio")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageAspectRatio { get; set; }

        [JsonPropertyName("imageSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageSize { get; set; }
    }
}
