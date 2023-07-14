using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class DeliveryContext
    {
        [JsonPropertyName("isRedelivery")]
        public bool IsRedelivery { get; set; }
    }
}
