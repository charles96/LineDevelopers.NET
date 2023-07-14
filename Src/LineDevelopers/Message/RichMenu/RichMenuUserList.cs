using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuUserList
    {
        [JsonPropertyName("userIds")]
        public required IList<string> UserIds { get; set; }
    }
}
