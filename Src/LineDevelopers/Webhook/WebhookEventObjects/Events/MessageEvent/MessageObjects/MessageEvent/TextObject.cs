using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(TextObject), "text")]
    public class TextObject : IMessageObject
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("emojis")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Emoji>? Emojis { get; set; }

        [JsonPropertyName("mention")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Mention? Mention { get; set; }
    }
}
