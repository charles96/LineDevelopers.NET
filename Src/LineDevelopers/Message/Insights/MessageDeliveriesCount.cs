using System.Text.Json.Serialization;

namespace Line.Message
{
    public class MessageDeliveriesCount
    {
        /// <summary>
        /// Status of the counting process
        /// Ready: Calculation has finished; the numbers are up-to-date.
        /// UnReady: We haven't finished calculating the number of sent messages for the specified date. Try again later. Calculation usually takes about a day.
        /// OutOfService: The specified date is earlier than the date on which we first started calculating sent messages (March 1, 2017).
        /// </summary>
        [JsonPropertyName("status")]
        public CalculationStatus Status { get; set; }

        /// <summary>
        /// Number of messages sent to all of this LINE Official Account's friends (broadcast messages).
        /// </summary>
        [JsonPropertyName("broadcast")]
        public int Broadcast { get; set; }

        /// <summary>
        /// Number of messages sent to some of this LINE Official Account's friends, based on specific attributes (targeted messages).
        /// </summary>
        [JsonPropertyName("targeting")]
        public int Targeting { get; set; }

        /// <summary>
        /// Number of auto-response messages sent.
        /// </summary>
        [JsonPropertyName("autoResponse")]
        public int AutoResponse { get; set; }

        /// <summary>
        /// Number of greeting messages sent.
        /// </summary>
        [JsonPropertyName("welcomeResponse")]
        public int WelcomeResponse { get; set; }

        /// <summary>
        /// Number of messages sent from LINE Official Account Manager Chat screen (opens new window)
        /// (only available in Japanese).
        /// </summary>
        [JsonPropertyName("chat")]
        public int Chat { get; set; }

        /// <summary>
        /// Number of broadcast messages sent with the Send broadcast message Messaging API operation.
        /// </summary>
        [JsonPropertyName("apiBroadcast")]
        public int ApiBroadcast { get; set; }

        /// <summary>
        /// Number of push messages sent with the Send push message Messaging API operation.
        /// </summary>
        [JsonPropertyName("apiPush")]
        public int ApiPush { get; set; }

        /// <summary>
        /// Number of multicast messages sent with the Send multicast message Messaging API operation.
        /// </summary>
        [JsonPropertyName("apiMulticast")]
        public int ApiMulticast { get; set; }

        /// <summary>
        /// Number of narrowcast messages sent with the Send narrowcast message Messaging API operation.
        /// </summary>
        [JsonPropertyName("apiNarrowcast")]
        public int ApiNarrowcast { get; set; }

        /// <summary>
        /// Number of replies sent with the Send reply message Messaging API operation.
        /// </summary>
        [JsonPropertyName("apiReply")]
        public int ApiReply { get; set; }

    }
}
