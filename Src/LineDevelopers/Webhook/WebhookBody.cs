using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class WebhookBody
    {
        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("events")]
        public IList<IWebhookEventObject> Events { get; set; }
    }
}
