using System.Text.Json.Serialization;

namespace Line.Message
{
    public class AgeItem
    {
        [JsonPropertyName("age")]
        public string Age { get; set; }

        [JsonPropertyName("percentage")]
        public decimal Percentage { get; set; }
    }
}
