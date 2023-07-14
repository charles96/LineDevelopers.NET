using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class Mention
    {
        [JsonPropertyName("mentionees")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Mentionee>? Mentionees { get; set; }
    }
}
