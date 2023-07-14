using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ScenarioExecutionThings), "scenarioResult")]
    public class ScenarioExecutionThings : IThings
    {
        [JsonPropertyName("deviceId")]
        public string DeviceId { get; set; }

        [JsonPropertyName("result")]
        public ThingsResult Result { get; set; }
    }
}
