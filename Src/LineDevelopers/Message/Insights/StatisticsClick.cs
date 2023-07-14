using System.Text.Json.Serialization;

namespace Line.Message
{
    public class StatisticsClick
    {
        [JsonPropertyName("seq")]
        public int Seq { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("click")]
        public int Click { get; set; }

        [JsonPropertyName("uniqueClick")]
        public int UniqueClick { get; set; }

        [JsonPropertyName("uniqueClickOfRequest")]
        public int UniqueClickOfRequest { get; set; }
    }
}
