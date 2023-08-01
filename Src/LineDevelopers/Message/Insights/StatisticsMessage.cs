using System.Text.Json.Serialization;

namespace Line.Message
{
    public class StatisticsMessage
    {
        [JsonPropertyName("seq")]
        public int Seq { get; set; }

        [JsonPropertyName("impression")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Impression { get; set; }

        [JsonPropertyName("mediaPlayed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MediaPlayed { get; set; }

        [JsonPropertyName("mediaPlayed25Percent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MediaPlayed25Percent { get; set; }

        [JsonPropertyName("mediaPlayed50Percent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MediaPlayed50Percent { get; set; }

        [JsonPropertyName("mediaPlayed75Percent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MediaPlayed75Percent { get; set; }

        [JsonPropertyName("mediaPlayed100Percent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MediaPlayed100Percent { get; set; }

        [JsonPropertyName("uniqueMediaPlayed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UniqueMediaPlayed { get; set; }

        [JsonPropertyName("uniqueMediaPlayed25Percent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UniqueMediaPlayed25Percent { get; set; }

        [JsonPropertyName("uniqueMediaPlayed50Percent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UniqueMediaPlayed50Percent { get; set; }

        [JsonPropertyName("uniqueMediaPlayed75Percent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UniqueMediaPlayed75Percent { get; set; }

        [JsonPropertyName("uniqueMediaPlayed100Percent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UniqueMediaPlayed100Percent { get; set; }
    }
}
