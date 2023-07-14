using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ConfirmTemplate), "confirm")]
    public class ConfirmTemplate : ITemplate
    {
        public ConfirmTemplate() { }

        [SetsRequiredMembers]
        public ConfirmTemplate(string text, IList<IAction> actions) 
        { 
            this.Text = text;
            this.Actions = actions;
        }

        /// <summary>
        /// Message text
        /// Max character limit: 240
        /// </summary>
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        /// <summary>
        /// Action when tapped
        /// Set 2 actions for the 2 buttons
        /// </summary>
        [JsonPropertyName("actions")]
        public required IList<IAction> Actions { get; set; }
    }
}
