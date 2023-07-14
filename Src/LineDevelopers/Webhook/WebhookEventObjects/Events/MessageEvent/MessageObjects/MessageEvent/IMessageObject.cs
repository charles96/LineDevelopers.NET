using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(TextObject), "text")]
    [JsonDerivedType(typeof(ImageObject), "image")]
    [JsonDerivedType(typeof(VideoObject), "video")]
    [JsonDerivedType(typeof(AudioObject), "audio")]
    [JsonDerivedType(typeof(FileObject), "file")]
    [JsonDerivedType(typeof(LocationObject), "location")]
    [JsonDerivedType(typeof(StickerObject), "sticker")]
    public interface IMessageObject
    {
        public string Id { get; set; }
    }
}
