using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class QuickReplyButtonObject
    {
        public QuickReplyButtonObject() { }
                
        [SetsRequiredMembers]
        public QuickReplyButtonObject(IAction action,
                                      string? imageUrl = null)
        {
            Action = action;
            ImageUrl = imageUrl;
        }

        [JsonPropertyName("type")]
        public string Type { get => "action"; }

        [JsonPropertyName("imageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("action")]
        public required IAction Action { get; set; }
    }
}
