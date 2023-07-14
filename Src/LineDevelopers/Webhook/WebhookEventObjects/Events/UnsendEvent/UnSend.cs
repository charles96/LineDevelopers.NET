using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class UnSend
    {
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }
    }
}
