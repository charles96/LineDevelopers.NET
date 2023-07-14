using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(TextMessage), "text")]
    [JsonDerivedType(typeof(StickerMessage), "sticker")]
    [JsonDerivedType(typeof(ImageMessage), "image")]
    [JsonDerivedType(typeof(VideoMessage), "video")]
    [JsonDerivedType(typeof(AudioMessage), "audio")]
    [JsonDerivedType(typeof(LocationMessage), "location")]
    [JsonDerivedType(typeof(ImageMapMessage), "imagemap")]
    [JsonDerivedType(typeof(TemplateMessage), "template")]
    [JsonDerivedType(typeof(FlexMessage), "flex")]
    public interface IMessage
    {
        public QuickReply? QuickReply { get; set; }
    }
}
