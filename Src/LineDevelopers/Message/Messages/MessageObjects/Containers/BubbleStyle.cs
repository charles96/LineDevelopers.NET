using System.Text.Json.Serialization;

namespace Line.Message
{
    public class BubbleStyle
    {
        public BubbleStyle() { }

        public BubbleStyle(BlockStyle? header = null,
                           BlockStyle? hero = null,
                           BlockStyle? body = null,
                           BlockStyle? footer = null)
        {
            Header = header;
            Hero = hero;
            Body = body;
            Footer = footer;
        }

        [JsonPropertyName("header")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BlockStyle? Header { get; set; }

        [JsonPropertyName("hero")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BlockStyle? Hero { get; set; }

        [JsonPropertyName("body")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BlockStyle? Body { get; set; }

        [JsonPropertyName("footer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BlockStyle? Footer { get; set; }
    }
}
