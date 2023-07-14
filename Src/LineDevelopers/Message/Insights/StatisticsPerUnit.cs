using System.Text.Json.Serialization;

namespace Line.Message
{
    public class StatisticsPerUnit : StatisticsBase
    {
        [JsonPropertyName("overview")]
        public StatisticsPerUnitOverview Overview { get; set; }
    }
}
