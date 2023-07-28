using System.Text.Json.Serialization;

namespace Line.Message
{
    public class UserInteractionStatisticsOverview
    {
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("delivered")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Delivered { get; set; }

        [JsonPropertyName("uniqueImpression")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UniqueImpression { get; set; }

        [JsonPropertyName("uniqueClick")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UniqueClick { get; set; }

        [JsonPropertyName("uniqueMediaPlayed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UniqueMediaPlayed { get; set; }

        [JsonPropertyName("uniqueMediaPlayed100Percent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UniqueMediaPlayed100Percent { get; set; }
    }
}
