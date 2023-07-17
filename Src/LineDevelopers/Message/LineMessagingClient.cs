namespace Line.Message
{
    public class LineMessagingClient : LineHttpClient
    {
        IMessageClient _messageClient;
        IMultiPersonChatClient _multiPersonChatClient;
        IGroupChatClient _groupChatClient;
        IInsightClient _insightClient;
        IRichMenuClient _richMenuClient;
        IUserClient _userClient;
        IAccountLinkClient _accountLinkClient;
        IWebHookSettingClient _webhookSettingClient;
        IBotClient _botClient;

        public LineMessagingClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { 
        }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        /// <summary>
        /// You can send a message and obtain information about the sent message.
        /// </summary>
        public IMessageClient Message => _messageClient ??= new LineMessageClient(base._httpClient, base._jsonSerializerOptions);

        /// <summary>
        /// You can obtain information about the group chats and their members that the LINE Official Account is a member of.
        /// </summary>
        public IGroupChatClient GroupChat => _groupChatClient ??= new LineGroupChatClient(base._httpClient, base._jsonSerializerOptions);
 
        /// <summary>
        /// You can obtain information about the multi-person chats and their members that the LINE Official Account is a member of.
        /// </summary>
        public IMultiPersonChatClient MultiPersonChat => _multiPersonChatClient ??= new LineMultiPersonChatClient(base._httpClient, base._jsonSerializerOptions);
 
        /// <summary>
        /// You can obtain information on the number of messages sent from the LINE Official Account, number of friends, and other statistical data.
        /// </summary>
        public IInsightClient Insight => _insightClient ??= new LineInsightClient(base._httpClient, base._jsonSerializerOptions);

        /// <summary>
        /// Customizable menu that is displayed on your LINE Official Account's chat screen.
        /// </summary>
        public IRichMenuClient RichMenu => _richMenuClient ??= new LineRichMenuClient(base._httpClient, base._jsonSerializerOptions);

        /// <summary>
        /// You can get information of users who have added your LINE Official Account as a friend.
        /// </summary>
        public IUserClient Users => _userClient ??= new LineUserClient(base._httpClient, base._jsonSerializerOptions);

        /// <summary>
        /// You can link the service account provided by the provider (corporate and developer) with the account of the LINE user.
        /// </summary>
        public IAccountLinkClient AccountLink => _accountLinkClient ??= new LineAccountLinkClient(base._httpClient, base._jsonSerializerOptions);

        /// <summary>
        /// You can configure, test, and get information on channel webhook endpoints.
        /// </summary>
        public IWebHookSettingClient WebhookSetting => _webhookSettingClient ??= new LineWebhookSettingClient(base._httpClient, base._jsonSerializerOptions);

        /// <summary>
        /// You can obtain basic information on the LINE Official Account's bots.
        /// </summary>
        public IBotClient Bot => _botClient ??= new LineBotClient(base._httpClient, base._jsonSerializerOptions);
    }
}
