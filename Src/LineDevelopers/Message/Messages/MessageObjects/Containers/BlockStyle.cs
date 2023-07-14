using System.Text.Json.Serialization;

namespace Line.Message
{
    public class BlockStyle
    {
        public BlockStyle() { }

        public BlockStyle(string? backgroundColor = null,
                          bool? separator = null,
                          string? separatorColor = null)
        {
            BackgroundColor = backgroundColor;
            Separator = separator;
            SeparatorColor = separatorColor;
        }

        [JsonPropertyName("backgroundColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BackgroundColor { get; set; }

        [JsonPropertyName("separator")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Separator { get; set; }

        [JsonPropertyName("separatorColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SeparatorColor { get; set; }
    }
}
