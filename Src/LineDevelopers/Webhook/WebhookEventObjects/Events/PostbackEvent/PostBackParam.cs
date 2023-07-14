using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class PostBackParam
    {
        [JsonPropertyName("date")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateOnly? Date { get; set; }

        [JsonPropertyName("time")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimeOnly? Time { get; set; }

        [JsonPropertyName("datetime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DateTime { get; set; }

        [JsonPropertyName("newRichMenuAliasId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NewRichMenuAliasId { get; set; }

        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RichMenuType? Status { get; set; }
    }
}
