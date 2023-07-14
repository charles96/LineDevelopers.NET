using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class ImageCarouselColumnObject
    {
        public ImageCarouselColumnObject() { }

        [SetsRequiredMembers]
        public ImageCarouselColumnObject(string imageUrl,
                                         IAction action) 
        { 
            this.ImageUrl = imageUrl;
            this.Action = action;
        }

        [JsonPropertyName("imageUrl")]
        public required string ImageUrl { get; set; }

        [JsonPropertyName("action")]
        public required IAction Action { get; set; }
    }
}
