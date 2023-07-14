using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuAliasList
    {
        [JsonPropertyName("aliases")]
        public IList<RichMenuAlias> Aliases { get; set; } = new List<RichMenuAlias>();
    }
}
