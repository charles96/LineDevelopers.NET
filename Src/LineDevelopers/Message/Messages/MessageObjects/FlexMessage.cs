using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(FlexMessage), "flex")]
    public class FlexMessage : IMessage
    {
        public FlexMessage() { }

        [SetsRequiredMembers]
        public FlexMessage(string altText,
                           IContainer container,
                           QuickReply? quickReply = null)
        { 
            this.AltText = altText;
            this.Contents = container;
            this.QuickReply = quickReply;  
        }

        [JsonPropertyName("quickReply")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QuickReply? QuickReply { get; set; }

        [JsonPropertyName("altText")]
        public required string AltText { get; set; }

        [JsonPropertyName("contents")]
        public required IContainer Contents { get; set; }
    }
}
