using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(BeaconEventObject), "beacon")]
    public class BeaconEventObject : IWebhookEventObject
    {
        [JsonPropertyName("mode")]
        public ModeType Mode { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("source")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ISource? Source { get; set; }

        [JsonPropertyName("webhookEventId")]
        public string WebhookEventId { get; set; }

        [JsonPropertyName("deliveryContext")]
        public DeliveryContext DeliveryContext { get; set; }

        [JsonPropertyName("replyToken")]
        public string ReplyToken { get; set; }

        [JsonPropertyName("beacon")]
        public Beacon Beacon { get; set; }
    }
}
