using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class VideoPlayComplate
    {
        [JsonPropertyName("trackingId")]
        public string TrackingId { get; set; }
    }
}
