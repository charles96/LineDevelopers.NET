using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class ThingsResult
    {
        [JsonPropertyName("scenarioId")]
        public string ScenarioId {  get; set; }

        [JsonPropertyName("revision")]
        public int Revision { get; set; }

        [JsonPropertyName("startTime")]
        public long StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public long EndTime { get; set; }

        [JsonPropertyName("resultCode")]
        public ThingsResultCode ResultCode { get; set; }

        [JsonPropertyName("actionResults")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<ThingsActionResult>? ActionResults { get; set; }

        [JsonPropertyName("bleNotificationPayload")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BleNotificationPayload { get; set; }

        [JsonPropertyName("errorReason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ErrorReason { get; set; }
    }
}
