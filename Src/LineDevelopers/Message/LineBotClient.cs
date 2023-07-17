using System.Text.Json;

namespace Line.Message
{
    public class LineBotClient : LineHttpClient, IBotClient
    {
        public LineBotClient(string channelAccessToken, double timeout = 100d)
       : base(channelAccessToken, timeout)
        { }

        internal LineBotClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        /// <summary>
        /// Gets a bot's basic information.
        /// </summary>
        /// <returns></returns>
        public async Task<BotInformation> GetBotInformationAsync()
            => await base.GetAsync<BotInformation>($"v2/bot/info").ConfigureAwait(false);

    }
}
