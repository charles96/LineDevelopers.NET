using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(DeviceUnlinkThings), "unlink")]
    public class DeviceUnlinkThings : IThings
    {
        [JsonPropertyName("deviceId")]
        public string DeviceId { get; set; }
    }
}
