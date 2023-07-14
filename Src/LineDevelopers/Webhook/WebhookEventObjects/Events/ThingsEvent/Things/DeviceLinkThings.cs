using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(DeviceLinkThings), "link")]
    public class DeviceLinkThings : IThings
    {
        [JsonPropertyName("deviceId")]
        public string DeviceId { get; set; }
    }
}
