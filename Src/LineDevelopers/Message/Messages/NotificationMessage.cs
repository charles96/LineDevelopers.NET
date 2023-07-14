using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class NotificationMessage
    {
        public NotificationMessage() { }

        [SetsRequiredMembers]
        public NotificationMessage(string to,
                                   IList<IMessage> messages) 
        { 
            this.To = to;
            this.Messages = messages;
        }

        /// <summary>
        /// ID of the target recipient. Use a userId, groupId, or roomId value returned in a webhook event object.
        /// </summary>
        [JsonPropertyName("to")]
        public required string To { get; set; }

        /// <summary>
        /// Messages to send
        /// Max: 5
        /// </summary>
        [JsonPropertyName("messages")]
        public required IList<IMessage> Messages { get; set; }
    }
}
