﻿using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(UnFollowEventObject), "unfollow")]
    public class UnFollowEventObject : IWebhookEventObject
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
    }
}
