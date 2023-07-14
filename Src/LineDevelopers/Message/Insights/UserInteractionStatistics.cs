using System.Text.Json.Serialization;

namespace Line.Message
{
    public class UserInteractionStatistics : StatisticsBase
    {
        [JsonPropertyName("overview")]
        public UserInteractionStatisticsOverview Overview { get; set; }
    }
}
