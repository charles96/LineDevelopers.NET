using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(TemplateMessage), "template")]
    public class TemplateMessage : IMessage
    {
        public TemplateMessage() { }

        [SetsRequiredMembers]
        public TemplateMessage(string altText,
                               ITemplate template,
                               QuickReply? quickReply = null) 
        { 
            this.AltText = altText;
            this.Template = template;
            this.QuickReply = quickReply;
        }

        [JsonPropertyName("quickReply")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QuickReply? QuickReply { get; set; }

        [JsonPropertyName("altText")]
        public required string AltText { get; set; }

        /// <summary>
        /// A Buttons, Confirm, Carousel, or Image Carousel object.
        /// </summary>
        [JsonPropertyName("template")]
        public required ITemplate Template { get; set; }
    }
}
