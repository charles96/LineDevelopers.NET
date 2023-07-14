using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class Link
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }
    }
}
