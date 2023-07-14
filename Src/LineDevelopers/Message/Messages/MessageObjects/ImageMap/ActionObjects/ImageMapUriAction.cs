using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ImageMapUriAction), "uri")]
    public class ImageMapUriAction : IImageMapAction
    {
        public ImageMapUriAction() { }

        [SetsRequiredMembers]
        public ImageMapUriAction(string linkUri,
                                 ImageMapArea area,
                                 string? Label = null)
        { 
            this.LinkUri = linkUri;
            this.Area = area;
            this.Label = Label;
        }

        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        [JsonPropertyName("linkUri")]
        public required string LinkUri { get; set; }

        [JsonPropertyName("area")]
        public required ImageMapArea Area { get; set; }
    }
}
