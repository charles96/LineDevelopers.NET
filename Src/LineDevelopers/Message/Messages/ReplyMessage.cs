using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class ReplyMessage
    {
        public ReplyMessage() { }

        [SetsRequiredMembers]
        public ReplyMessage(string replyToken,
                            IList<IMessage> messages,
                            bool? notificationDisabled = null)
        {
            ReplyToken = replyToken;
            Messages = messages;
            NotificationDisabled = notificationDisabled;
        }

        /// <summary>
        /// Reply token received via webhook
        /// </summary>
        [JsonPropertyName("replyToken")]
        public required string ReplyToken { get; set; }

        [JsonPropertyName("messages")]
        public required IList<IMessage> Messages { get; set; }

        [JsonPropertyName("notificationDisabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? NotificationDisabled { get; set; }
    }
}
