using System.Text.Json.Serialization;

namespace Line.Webhook
{
    public class Emoji
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("emojiId")]
        public string EmojiId { get; set; }
    }
}
