using System.Text.Json.Serialization;

namespace Line.Message
{
    public class StatisticsPerUnitOverview
    {
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
