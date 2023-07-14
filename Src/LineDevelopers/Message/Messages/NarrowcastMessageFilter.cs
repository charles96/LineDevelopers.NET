using System.Text.Json.Serialization;

namespace Line.Message
{
    public class NarrowcastMessageFilter
    {
        [JsonPropertyName("demographic")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IDemographicFilterObjects? Demographic { get; set; }
    }
}
