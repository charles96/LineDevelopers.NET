using System.Text.Json.Serialization;

namespace Line.Message
{
    public class AppTypeItem
    {
        [JsonPropertyName("appType")]
        public string AppType { get; set; }

        [JsonPropertyName("percentage")]
        public decimal Percentage { get; set; }
    }
}
