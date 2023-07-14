using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(MessageAction), "message")]
    public class MessageAction : IAction
    {
        public MessageAction() { }

        [SetsRequiredMembers]
        public MessageAction(string text,
                             string? label = null)
        { 
            this.Text = text;
            this.Label = label;
        }

        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        [JsonPropertyName("text")]
        public required string Text { get; set; }
    }
}
