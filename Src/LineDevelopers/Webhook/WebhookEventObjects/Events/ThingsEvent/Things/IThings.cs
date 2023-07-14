using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(DeviceLinkThings), "link")]
    [JsonDerivedType(typeof(DeviceUnlinkThings), "unlink")]
    [JsonDerivedType(typeof(ScenarioExecutionThings), "scenarioResult")]
    public interface IThings
    {
        public string DeviceId { get; set; }
    }
}
