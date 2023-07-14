using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class BroadcastMessage
    {
        public BroadcastMessage() { }

        [SetsRequiredMembers]
        public BroadcastMessage(IList<IMessage> messages,
                                bool? notificationDisabled = null)
        {
            Messages = messages;
            NotificationDisabled = notificationDisabled;
        }

        [JsonPropertyName("messages")]
        public required IList<IMessage> Messages { get; set; }

        [JsonPropertyName("notificationDisabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? NotificationDisabled { get; set; }
    }
}
