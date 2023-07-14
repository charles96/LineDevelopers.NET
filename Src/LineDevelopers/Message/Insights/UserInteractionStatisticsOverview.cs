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
        public int Delivered { get; set; }

        [JsonPropertyName("uniqueImpression")]
        public int UniqueImpression { get; set; }

        [JsonPropertyName("uniqueClick")]
        public int UniqueClick { get; set; }

        [JsonPropertyName("uniqueMediaPlayed")]
        public int UniqueMediaPlayed { get; set; }

        [JsonPropertyName("uniqueMediaPlayed100Percent")]
        public int UniqueMediaPlayed100Percent { get; set; }

    }
}
