using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Line.Message
{
    public class LineMessageClient : LineHttpClient, IMessageClient
    {
        readonly string X_LINE_RETRY_KEY = "X-Line-Retry-Key";

        public LineMessageClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { }

        internal LineMessageClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        #region SendReplyMessageAsync
        private async Task SendReplyMessageAsync(ReplyMessage replyMessage, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.PostAsJsonAsync("v2/bot/message/reply", replyMessage, getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Sends a reply message in response to an event from a user, group chat, or multi-person chat. To send reply messages, you need a reply token which is included in the webhook event object.
        /// </summary>
        /// <param name="replyToken">Reply token received via webhook</param>
        /// <param name="message">Messages to send</param>
        /// <param name="notificationDisabled">
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).
        /// </param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SendReplyMessageAsync(string replyToken, IMessage message, bool? notificationDisabled = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new ReplyMessage()
            {
                ReplyToken = replyToken,
                Messages = new List<IMessage>() { message },
                NotificationDisabled = notificationDisabled
            };

            await this.SendReplyMessageAsync(request, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a reply message in response to an event from a user, group chat, or multi-person chat. To send reply messages, you need a reply token which is included in the webhook event object.
        /// </summary>
        /// <param name="replyToken">Reply token received via webhook</param>
        /// <param name="messages">Messages to send. Max: 5</param>
        /// <param name="notificationDisabled">
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).
        /// </param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SendReplyMessageAsync(string replyToken, IList<IMessage> messages, bool? notificationDisabled = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new ReplyMessage()
            {
                ReplyToken = replyToken,
                Messages = messages,
                NotificationDisabled = notificationDisabled
            };

            await this.SendReplyMessageAsync(request, getResponseHeaders).ConfigureAwait(false);
        }
        #endregion

        #region SendPushMessageAsync
        private async Task SendPushMessageAsync(PushMessage pushMessage, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.PostAsJsonAsync("v2/bot/message/push", pushMessage, X_LINE_RETRY_KEY, xLineRetryKey, getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Sends a message to a user, group chat, or multi-person chat at any time.
        /// </summary>
        /// <param name="to">ID of the target recipient.</param>
        /// <param name="messages">Messages to send. Max: 5</param>
        /// <param name="notificationDisabled">
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).
        /// </param>
        /// <param name="customAggregationUnits">Name of aggregation unit. Case-sensitive. For example, Promotion_a and Promotion_A are regarded as different unit names.</param>
        /// <param name="xLineRetryKey">Retry key. Specifies the UUID in hexadecimal format (e.g., 123e4567-e89b-12d3-a456-426614174000) generated by any method.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SendPushMessageAsync(string to, IList<IMessage> messages, bool? notificationDisabled = null, IList<string>? customAggregationUnits = null, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new PushMessage()
            {
                To = to,
                Messages = messages,
                CustomAggregationUnits = customAggregationUnits,
                NotificationDisabled = notificationDisabled
            };

            await this.SendPushMessageAsync(request, xLineRetryKey, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a message to a user, group chat, or multi-person chat at any time.
        /// </summary>
        /// <param name="to">ID of the target recipient.</param>
        /// <param name="message">Messages to send.</param>
        /// <param name="notificationDisabled">
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).
        /// </param>
        /// <param name="customAggregationUnits">Name of aggregation unit. Case-sensitive. For example, Promotion_a and Promotion_A are regarded as different unit names.</param>
        /// <param name="xLineRetryKey">Retry key. Specifies the UUID in hexadecimal format (e.g., 123e4567-e89b-12d3-a456-426614174000) generated by any method.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SendPushMessageAsync(string to, IMessage message, bool? notificationDisabled = null, IList<string>? customAggregationUnits = null, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new PushMessage()
            {
                To = to,
                Messages = new List<IMessage>() { message },
                CustomAggregationUnits = customAggregationUnits,
                NotificationDisabled = notificationDisabled
            };

            await this.SendPushMessageAsync(request, xLineRetryKey, getResponseHeaders).ConfigureAwait(false);
        }
        #endregion

        #region SendMulticastMessageAsync
        private async Task SendMulticastMessageAsync(MulticastMessage multicastMessage, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.PostAsJsonAsync("v2/bot/message/multicast", multicastMessage, X_LINE_RETRY_KEY, xLineRetryKey, getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// An API that efficiently sends the same message to multiple user IDs. You can't send messages to group chats or multi-person chats.
        /// </summary>
        /// <param name="to">Array of user IDs. Use userId values which are returned in webhook event objects. Do not use LINE IDs found on LINE.</param>
        /// <param name="messages">Messages to send. Max:5</param>
        /// <param name="notificationDisabled">
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).
        /// </param>
        /// <param name="customAggregationUnits">Name of aggregation unit. Case-sensitive. For example, Promotion_a and Promotion_A are regarded as different unit names.</param>
        /// <param name="xLineRetryKey">Retry key. Specifies the UUID in hexadecimal format (e.g., 123e4567-e89b-12d3-a456-426614174000) generated by any method</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SendMulticastMessageAsync(IList<string> to, IList<IMessage> messages, bool? notificationDisabled = null, IList<string>? customAggregationUnits = null, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new MulticastMessage()
            {
                To = to,
                Messages = messages,
                NotificationDisabled = notificationDisabled,
                CustomAggregationUnits = customAggregationUnits
            };

            await this.SendMulticastMessageAsync(request, xLineRetryKey, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// An API that efficiently sends the same message to multiple user IDs. You can't send messages to group chats or multi-person chats.
        /// </summary>
        /// <param name="to">Array of user IDs. Use userId values which are returned in webhook event objects. Do not use LINE IDs found on LINE.</param>
        /// <param name="message">Messages to send.</param>
        /// <param name="notificationDisabled">
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).
        /// </param>
        /// <param name="customAggregationUnits">Name of aggregation unit. Case-sensitive. For example, Promotion_a and Promotion_A are regarded as different unit names.</param>
        /// <param name="xLineRetryKey">Retry key. Specifies the UUID in hexadecimal format (e.g., 123e4567-e89b-12d3-a456-426614174000) generated by any method</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SendMulticastMessageAsync(IList<string> to, IMessage message, bool? notificationDisabled = null, IList<string>? customAggregationUnits = null, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new MulticastMessage()
            {
                To = to,
                Messages = new List<IMessage>() { message },
                NotificationDisabled = notificationDisabled,
                CustomAggregationUnits = customAggregationUnits
            };

            await this.SendMulticastMessageAsync(request, xLineRetryKey, getResponseHeaders).ConfigureAwait(false);
        }
        #endregion

        #region SendNarrowcastMessageAsync
        private async Task SendNarrowcastMessageAsync(NarrowcastMessage narrowcastMessage, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.PostAsJsonAsync("v2/bot/message/narrowcast", narrowcastMessage, X_LINE_RETRY_KEY, xLineRetryKey, getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Sends a message to multiple users. You can specify recipients using attributes (such as age, gender, OS, and region) or by retargeting (audiences). Messages can't be sent to group chats or multi-person chats.
        /// </summary>
        /// <param name="messages">Messages to send. Max: 5</param>
        /// <param name="recipient">
        /// Recipient object. You can use up to a combined total of 10 audiences and request IDs of the narrowcast messages previously sent to specify message recipients. 
        /// There is no upper limit on the number of operator objects that you can specify.
        /// If this is omitted, messages will be sent to all users who have added your LINE Official Account as a friend.
        /// </param>
        /// <param name="filter">
        /// Demographic filter object. You can use friends' attributes to filter the list of recipients.
        /// If this is omitted, messages are sent to everyone—including users with attribute values of "unknown".
        /// </param>
        /// <param name="limit">
        /// The maximum number of narrowcast messages to send. 
        /// </param>
        /// <param name="notificationDisabled">
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or on their device).
        /// </param>
        /// <param name="xLineRetryKey">Retry key. Specifies the UUID in hexadecimal format (e.g., 123e4567-e89b-12d3-a456-426614174000) generated by any method.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SendNarrowcastMessageAsync(IList<IMessage> messages, IRecipientObject? recipient = null, NarrowcastMessageFilter? filter = null, NarrowcastLimit? limit = null, bool? notificationDisabled = null, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        { 
            var request = new NarrowcastMessage()
            {
                Messages = messages,
                Recipient = recipient,
                Filter = filter,
                Limit = limit,
                NotificationDisabled = notificationDisabled
            };
            
            await this.SendNarrowcastMessageAsync(request, xLineRetryKey, getResponseHeaders).ConfigureAwait(!false);
        }

        /// <summary>
        /// Sends a message to multiple users. You can specify recipients using attributes (such as age, gender, OS, and region) or by retargeting (audiences). Messages can't be sent to group chats or multi-person chats.
        /// </summary>
        /// <param name="message">Messages to send.</param>
        /// <param name="recipient">
        /// Recipient object. You can use up to a combined total of 10 audiences and request IDs of the narrowcast messages previously sent to specify message recipients. 
        /// There is no upper limit on the number of operator objects that you can specify.
        /// If this is omitted, messages will be sent to all users who have added your LINE Official Account as a friend.
        /// </param>
        /// <param name="filter">
        /// Demographic filter object. You can use friends' attributes to filter the list of recipients.
        /// If this is omitted, messages are sent to everyone—including users with attribute values of "unknown".
        /// </param>
        /// <param name="limit">
        /// The maximum number of narrowcast messages to send. 
        /// </param>
        /// <param name="notificationDisabled">
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or on their device).
        /// </param>
        /// <param name="xLineRetryKey">Retry key. Specifies the UUID in hexadecimal format (e.g., 123e4567-e89b-12d3-a456-426614174000) generated by any method.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SendNarrowcastMessageAsync(IMessage message, IRecipientObject? recipient = null, NarrowcastMessageFilter? filter = null, NarrowcastLimit? limit = null, bool? notificationDisabled = null, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new NarrowcastMessage()
            {
                Messages = new List<IMessage>() { message },
                Recipient = recipient,
                Filter = filter,
                Limit = limit,
                NotificationDisabled = notificationDisabled
            };

            await this.SendNarrowcastMessageAsync(request, xLineRetryKey, getResponseHeaders).ConfigureAwait(!false);
        }
        #endregion

        #region SendBroadcastMessageAsync
        private async Task SendBroadcastMessageAsync(BroadcastMessage broadcastMessage, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            await base.PostAsJsonAsync("v2/bot/message/broadcast", broadcastMessage, X_LINE_RETRY_KEY, xLineRetryKey, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a message to all users who are friends with your LINE Official Account at any time.
        /// </summary>
        /// <param name="messages">Messages to send. Max:5</param>
        /// <param name="notificationDisabled">
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).
        /// </param>
        /// <param name="xLineRetryKey">Retry key. Specifies the UUID in hexadecimal format (e.g., 123e4567-e89b-12d3-a456-426614174000) generated by any method.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SendBroadcastMessageAsync(IList<IMessage> messages, bool? notificationDisabled = null, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new BroadcastMessage()
            {
                Messages = messages,
                NotificationDisabled = notificationDisabled
            };
            
            await this.SendBroadcastMessageAsync(request,xLineRetryKey, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a message to all users who are friends with your LINE Official Account at any time.
        /// </summary>
        /// <param name="message">Messages to send.</param>
        /// <param name="notificationDisabled">
        /// true: The user doesn't receive a push notification when the message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).
        /// </param>
        /// <param name="xLineRetryKey">Retry key. Specifies the UUID in hexadecimal format (e.g., 123e4567-e89b-12d3-a456-426614174000) generated by any method.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SendBroadcastMessageAsync(IMessage message, bool? notificationDisabled = null, string? xLineRetryKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new BroadcastMessage()
            {
                Messages = new List<IMessage>() { message },
                NotificationDisabled = notificationDisabled
            };

            await this.SendBroadcastMessageAsync(request, xLineRetryKey, getResponseHeaders).ConfigureAwait(false);
        }
        #endregion

        /// <summary>
        /// Gets the status of a narrowcast message.
        /// </summary>
        /// <param name="requestId">The narrowcast message's request ID. Each Messaging API request has a request ID. Find it in the response headers.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<NarrowcastMessageStatus> GetNarrowcastMessageStatusAsync(string requestId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<NarrowcastMessageStatus>($"v2/bot/message/progress/narrowcast?requestId={requestId}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Gets the target limit for sending messages in the current month. The total number of the free messages and the additional messages is returned.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<TargetLimitForSendingMessagesThisMonth> GetTheTargetLimitForSendingMessagesThisMonthAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<TargetLimitForSendingMessagesThisMonth>("v2/bot/message/quota", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Gets the number of messages sent in the current month.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<int> GetNumberOfMessagesSentThisMonthAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var result = await base.GetAsync<JsonNode>("v2/bot/message/quota/consumption", getResponseHeaders).ConfigureAwait(false);
            return result["totalUsage"].GetValue<int>();
        }

        /// <summary>
        /// Gets the number of messages sent with the Send(Reply,Push,Multicast,Narrowcast,Broadcast)MessageAsync method.
        /// /// </summary>
        /// <param name="sendType">Send Type</param>
        /// <param name="date">Date the messages were sent</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public async Task<NumberOfSentMessages> GetNumberOfSentMessagesAsync(SendType sendType, DateOnly date, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            if (sendType == SendType.Narrowcast) throw new NotSupportedException();
            return await base.GetAsync<NumberOfSentMessages>($"v2/bot/message/delivery/{sendType.ToString().ToLower()}?date={date.ToString("yyyyMMdd")}", getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// You can validate that an array of message objects is valid as a value for the messages property of the request body for the Send reply message endpoint. This endpoint doesn't validate the values of the properties other than the messages property.
        /// </summary>
        /// <param name="sendType">Send Type</param>
        /// <param name="messages">Array of message objects to validate</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task ValidateMessageObjectsOfMessageAsync(SendType sendType, IList<IMessage> messages, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.PostAsJsonAsync<RequestMessages>($"v2/bot/message/validate/{sendType.ToString().ToLower()}", new RequestMessages() { Message = messages }, getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// You can validate that an array of message objects is valid as a value for the messages property of the request body for the Send reply message endpoint. This endpoint doesn't validate the values of the properties other than the messages property.
        /// </summary>
        /// <param name="sendType">Send Type</param>
        /// <param name="message">message objects to validate</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task ValidateMessageObjectsOfMessageAsync(SendType sendType, IMessage message, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await this.ValidateMessageObjectsOfMessageAsync(sendType, new List<IMessage> { message }, getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Get the number of aggregation units used this month.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<int> GetNumberOfUnitsUsedThisMonthAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var result = await base.GetAsync<JsonNode>("v2/bot/message/aggregation/info",getResponseHeaders).ConfigureAwait(false);
            return result["numOfCustomAggregationUnits"].GetValue<int>();
        }

        /// <summary>
        /// You can get the name list of units used this month for statistics aggregation.
        /// </summary>
        /// <param name="limit">
        /// The maximum number of aggregation units you can get per request. 
        /// The default value is 100
        /// Max value: 100
        /// </param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<NameListOfUnitsUsedThisMonth> GetNameListOfUnitsUsedThisMonthAsync(int limit = 100, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<NameListOfUnitsUsedThisMonth>($"v2/bot/message/aggregation/list?limit={limit}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// You can get the name list of units used this month for statistics aggregation.
        /// </summary>
        /// <param name="limit">
        /// The maximum number of aggregation units you can get per request. 
        /// The default value is 100
        /// Max value: 100
        /// </param>
        /// <param name="start">Value of the continuation token found in the next property of the JSON object returned in the response. If you can't get all the aggregation units in one request, include this parameter to get the remaining array.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<NameListOfUnitsUsedThisMonth> GetNameListOfUnitsUsedThisMonthAsync(int limit, string start, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<NameListOfUnitsUsedThisMonth>($"v2/bot/message/aggregation/list?limit={limit}&start={start}", getResponseHeaders).ConfigureAwait(false);
    }
}
