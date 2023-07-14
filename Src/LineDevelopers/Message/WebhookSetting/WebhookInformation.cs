using System.Text.Json.Serialization;

namespace Line.Message
{
    public class WebhookInformation
    {
        [JsonPropertyName("endpoint")]
        public string Endpoint { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }
}
