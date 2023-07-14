using System.Text.Json.Serialization;

namespace Line.Message
{
    public class GenderItem
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("percentage")]
        public decimal Percentage { get; set; }
    }
}
