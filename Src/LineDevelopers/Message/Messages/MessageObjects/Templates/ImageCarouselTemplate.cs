using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ImageCarouselTemplate), "image_carousel")]
    public class ImageCarouselTemplate : ITemplate
    {
        public ImageCarouselTemplate() { }

        [SetsRequiredMembers]
        public ImageCarouselTemplate(IList<ImageCarouselColumnObject> columns)
        { 
            this.Columns = columns;
        }

        [JsonPropertyName("columns")]
        public required IList<ImageCarouselColumnObject> Columns { get; set; }
    }
}
