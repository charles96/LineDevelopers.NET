using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(StickerObject), "sticker")]
    public class StickerObject : IMessageObject
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("packageId")]
        public string PackageId { get; set; }

        [JsonPropertyName("stickerId")]
        public string StickerId { get; set; }

        [JsonPropertyName("stickerResourceType")]
        public StickerResourceType StickerResourceType { get; set; }

        [JsonPropertyName("keywords")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<string>? Keywords { get; set; }

        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Text { get; set; }
    }
}
