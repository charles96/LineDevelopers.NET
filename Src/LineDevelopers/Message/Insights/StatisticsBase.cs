using System.Text.Json.Serialization;

namespace Line.Message
{
    public class StatisticsBase
    {
        [JsonPropertyName("messages")]
        public IList<StatisticsMessage> Messages { get; set; }

        [JsonPropertyName("clicks")]
        public IList<StatisticsClick> Clicks { get; set; }
    }
}
