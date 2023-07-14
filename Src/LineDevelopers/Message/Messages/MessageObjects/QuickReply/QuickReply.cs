using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class QuickReply
    {
        public QuickReply() { }

        [SetsRequiredMembers]
        public QuickReply(IList<QuickReplyButtonObject> items) 
        { 
            Items = items;
        }

        [JsonPropertyName("items")]
        public required IList<QuickReplyButtonObject> Items { get; set; }
    }
}
