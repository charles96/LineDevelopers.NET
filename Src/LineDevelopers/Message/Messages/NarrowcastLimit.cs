using System.Text.Json.Serialization;

namespace Line.Message
{
    public class NarrowcastLimit
    {
        [JsonPropertyName("max")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Max { get; set; }

        [JsonPropertyName("upToRemainingQuota")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UpToRemainingQuota { get; set; }
    }
}
