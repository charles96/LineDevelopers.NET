using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class MemeberGroup
    {
        [JsonPropertyName("members")]
        public IList<UserSource> Members { get; set; }
    }
}
