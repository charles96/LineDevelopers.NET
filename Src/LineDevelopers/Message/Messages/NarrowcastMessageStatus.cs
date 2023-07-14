using System.Text.Json.Serialization;

namespace Line.Message
{
    public class NarrowcastMessageStatus
    {
        [JsonPropertyName("phase")]
        public PhaseType Type { get; set; }

        [JsonPropertyName("successCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SuccessCount { get; set; }

        [JsonPropertyName("failureCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FailureCount { get; set; }

        [JsonPropertyName("targetCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TargetCount { get; set; }

        [JsonPropertyName("failedDescription")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FailedDescription { get; set; }

        [JsonPropertyName("errorCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ErrorCode { get; set; }

        [JsonPropertyName("acceptedTime")]
        public string AcceptedTime { get; set; }

        [JsonPropertyName("completedTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CompletedTime { get; set; }
    }
}
