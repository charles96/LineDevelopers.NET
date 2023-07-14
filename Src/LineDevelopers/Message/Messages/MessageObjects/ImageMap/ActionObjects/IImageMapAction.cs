using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ImageMapMessageAction), "message")]
    [JsonDerivedType(typeof(ImageMapUriAction), "uri")]
    public interface IImageMapAction
    {
    }
}
