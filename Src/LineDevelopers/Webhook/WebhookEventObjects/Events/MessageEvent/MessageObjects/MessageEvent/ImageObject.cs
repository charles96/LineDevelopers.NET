using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ImageObject), "image")]
    public class ImageObject : IMessageObject
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("contentProvider")]
        public ContentProvider ContentProvider { get; set; }

        [JsonPropertyName("imageSet")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageSet? ImageSet { get; set; }
    }
}
