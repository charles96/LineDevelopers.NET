using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class MulticastMessage
    {
        public MulticastMessage() { }

        [SetsRequiredMembers]
        public MulticastMessage(IList<string> to,
                                IList<IMessage> messages,
                                bool? notificationDisabled = null,
                                IList<string>? customAggregationUnits = null) 
        { 
            this.To = to;
            this.Messages = messages;
            this.NotificationDisabled = notificationDisabled;
            this.CustomAggregationUnits = customAggregationUnits;
        }

        /// <summary>
        /// Array of user IDs. Use userId values which are returned in webhook event objects. 
        /// Do not use LINE IDs found on LINE.
        /// Max: 500 user IDs
        /// </summary>
        [JsonPropertyName("to")]
        public required IList<string> To { get; set; }

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
        public IList<string>? CustomAggregationUnits { get; set; }
    }
}
