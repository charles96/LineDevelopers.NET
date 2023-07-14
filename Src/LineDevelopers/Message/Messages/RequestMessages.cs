using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RequestMessages
    {
        public RequestMessages() { }

        [SetsRequiredMembers]
        public RequestMessages(IList<IMessage> message)
            => Message = message;

        [JsonPropertyName("messages")]
        public required IList<IMessage> Message { get; set; }
    }
}
