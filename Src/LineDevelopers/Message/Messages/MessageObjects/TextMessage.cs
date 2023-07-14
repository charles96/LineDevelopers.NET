using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(TextMessage), "text")]
    public class TextMessage : IMessage
    {
        public TextMessage() { }

        [SetsRequiredMembers]
        public TextMessage(string text,
                           QuickReply? quickReply = null,
                           IList<Emoji>? emojis = null)
        {
            QuickReply = quickReply;
            Text = text;
            Emojis = emojis;
        }

        [JsonPropertyName("quickReply")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QuickReply? QuickReply { get; set; }

        /// <summary>
        /// Message text. You can include the following emoji:
        /// LINE emojis.Use a $ character as a placeholder and specify the product ID and emoji ID of the LINE emoji you want to use in the emojis property.For more information, see List of available LINE emojis.
        /// Unicode emojis
        /// Max character limit: 5000
        /// </summary>
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        [JsonPropertyName("emojis")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Emoji>? Emojis { get; set; }
    }
}
