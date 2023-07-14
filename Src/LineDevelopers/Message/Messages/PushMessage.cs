using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class PushMessage
    {
        public PushMessage() { }

        [SetsRequiredMembers]
        public PushMessage(string to,
                           IList<IMessage> messages,
                           bool? notificationDisabled = null,
                           string[]? CustomAggregationUnits = null) 
        {
            this.To = to;
            this.Messages = messages;
            this.NotificationDisabled = notificationDisabled;
            this.CustomAggregationUnits = CustomAggregationUnits;
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

        /// <summary>
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).
        /// Default: false
        /// </summary>
        [JsonPropertyName("notificationDisabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? NotificationDisabled { get; set; }

        /// <summary>
        /// Name of aggregation unit. Case-sensitive. For example, Promotion_a and Promotion_A are regarded as different unit names.
        /// </summary>
        [JsonPropertyName("customAggregationUnits")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? CustomAggregationUnits { get; set; }
    }
}
