using Line.Message;

namespace Line.Options
{
    public class LineOptionsClient : LineHttpClient
    {
        readonly string X_Line_Delivery_Tag = "X-Line-Delivery-Tag";

        public LineOptionsClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        #region SendMulticastMessageUsingPhoneNumberAsync
        /// <summary>
        /// Serves targeting delivery based on the user's phone number.
        /// </summary>
        /// <param name="to">Destination of the message (A value obtained by hashing the telephone number, which is another value normalized to E.164 format, with SHA256).
        /// Max message limit: 150
        /// </param>
        /// <param name="messages">Message to send.</param>
        /// <param name="notificationDisabled">
        /// true: The user doesn’t receive a push notification when a message is sent.
        /// false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).
        /// The default value is false.
        /// </param>
        /// <returns></returns>
        public async Task SendMulticastMessageUsingPhoneNumberAsync(IList<string> to, IList<IMessage> messages, bool? notificationDisabled = null)
        {
            var encTo = new List<string>();

            foreach (var phoneNumber in to)
            {
                encTo.Add(await PhoneNumber.EncryptSHA256Async(phoneNumber).ConfigureAwait(false));    
            }

            var request = new MulticastMessage()
            {
                To = encTo,
                Messages = messages,
                NotificationDisabled = notificationDisabled
            };

            await base.PostAsJsonAsync("bot/ad/multicast/phone", request).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the delivery result of the message delivered in SendMulticastMessageUsingPhoneNumberAsync.
        /// </summary>
        /// <param name="date">Date the message was sent</param>
        /// <returns></returns>
        public async Task<NumberOfSentMessages> GetResultOfMulticastMessageUsingPhoneNumberAsync(DateOnly date)
            => await base.GetAsync<NumberOfSentMessages>($"v2/bot/message/delivery/ad_phone?date={date.ToString("yyyyMMdd")}").ConfigureAwait(false);
        #endregion

        /// <summary>
        /// An API that sends a LINE notification message by specifying the user's phone number.
        /// </summary>
        /// <param name="to">Message destination. Specify a phone number that has been normalized to E.164 format and hashed with SHA256.</param>
        /// <param name="messages">Message to be sent. Max: 5</param>
        /// <param name="xLineDeliveryTag"></param>
        /// <returns></returns>
        public async Task SendNotificationMessageUsingPhoneNumberAsync(string to, IList<IMessage> messages, string? xLineDeliveryTag = null)
        {
            var request = new NotificationMessage()
            {
                To = await PhoneNumber.EncryptSHA256Async(to).ConfigureAwait(false),
                Messages = messages
            };

            await base.PostAsJsonAsync("bot/pnp/push", request, X_Line_Delivery_Tag, xLineDeliveryTag).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the number of LINE notification messages sent using GetNumberOfSentNotificationMessageAsync.
        /// </summary>
        /// <param name="date">Date the message was sent</param>
        /// <returns></returns>
        public async Task<NumberOfSentMessages> GetNumberOfSentNotificationMessageUsingPhoneNumberAsync(DateOnly date)
            => await base.GetAsync<NumberOfSentMessages>($"v2/bot/message/delivery/pnp?date={date.ToString("yyyyMMdd")}").ConfigureAwait(false);
    }
}
