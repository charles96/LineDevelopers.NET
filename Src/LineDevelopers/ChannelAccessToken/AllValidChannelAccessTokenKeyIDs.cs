using System.Text.Json.Serialization;

namespace Line
{
    public class AllValidChannelAccessTokenKeyIDs
    {
        [JsonPropertyName("kids")]
        public IList<string> Kids { get; set; }
    }
}
