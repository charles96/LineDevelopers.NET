using System.Text.Json.Serialization;

namespace Line.Message
{
    public class StatisticsMessage
    {
        [JsonPropertyName("seq")]
        public int seq { get; set; }

        [JsonPropertyName("impression")]
        public int impression { get; set; }

        [JsonPropertyName("mediaPlayed")]
        public int mediaPlayed { get; set; }

        [JsonPropertyName("mediaPlayed25Percent")]
        public int mediaPlayed25Percent { get; set; }

        [JsonPropertyName("mediaPlayed50Percent")]
        public int mediaPlayed50Percent { get; set; }

        [JsonPropertyName("mediaPlayed75Percent")]
        public int mediaPlayed75Percent { get; set; }

        [JsonPropertyName("mediaPlayed100Percent")]
        public int mediaPlayed100Percent { get; set; }
    }
}
