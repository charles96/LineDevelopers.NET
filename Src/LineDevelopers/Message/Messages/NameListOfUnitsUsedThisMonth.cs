using System.Text.Json.Serialization;

namespace Line.Message
{
    public class NameListOfUnitsUsedThisMonth
    {
        [JsonPropertyName("customAggregationUnits")]
        public string[] CustomAggregationUnits { get; set; }

        [JsonPropertyName("next")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Next { get; set; }
    }
}
