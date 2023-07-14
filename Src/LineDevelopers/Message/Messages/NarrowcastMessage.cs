using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class NarrowcastMessage
    {
        public NarrowcastMessage() { }

        [SetsRequiredMembers]
        public NarrowcastMessage(IList<IMessage> messages,
                                 IRecipientObject? recipient = null,
                                 NarrowcastMessageFilter? filter = null,
                                 NarrowcastLimit? limit = null,
                                 bool? notificationDisabled = null)
        {
            Messages = messages;
            Recipient = recipient;
            Filter = filter;
            Limit = limit;
            NotificationDisabled = notificationDisabled;
        }

        [JsonPropertyName("messages")]
        public required IList<IMessage> Messages { get; set; }

        [JsonPropertyName("recipient")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IRecipientObject? Recipient { get; set; }

        [JsonPropertyName("filter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NarrowcastMessageFilter? Filter { get; set; }

        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NarrowcastLimit? Limit { get; set; }

        [JsonPropertyName("notificationDisabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? NotificationDisabled { get; set; }
    }
}
