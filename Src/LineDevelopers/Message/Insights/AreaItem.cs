using System.Text.Json.Serialization;

namespace Line.Message
{
    public class AreaItem
    {
        [JsonPropertyName("areas")]
        public string Area { get; set; }

        [JsonPropertyName("percentage")]
        public decimal Percentage { get; set; }
    }
}
