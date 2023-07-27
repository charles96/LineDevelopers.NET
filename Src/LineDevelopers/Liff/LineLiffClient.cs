using System.Text.Json.Nodes;

namespace Line.Liff
{
    public class LineLiffClient : LineHttpClient
    {
        public LineLiffClient(string channelAccessToken, double timeout = 100d) 
            : base(channelAccessToken, timeout)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        /// <summary>
        /// Adds the LIFF app to a channel. You can add up to 30 LIFF apps on one channel.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="description">Name of the LIFF app.</param>
        /// <param name="features"></param>
        /// <param name="permanentLinkPattern"></param>
        /// <param name="scope"></param>
        /// <param name="botPrompt"></param>
        /// <returns></returns>
        public async Task<string> AddLiffAppToChannelAsync(View view,
                                                           string? description = null,
                                                           Features? features = null,
                                                           string? permanentLinkPattern = null,
                                                           IList<ScopeType>? scope = null,
                                                           BotPromptType? botPrompt = null)
        {
            var request = new LiffApp()
            {
                View = view,
                Description = description,
                Features = features,
                PermanentLinkPattern = permanentLinkPattern,
                Scope = scope,
                BotPrompt = botPrompt
            };

            var result = await base.PostAsJsonAsync<LiffApp, JsonNode>("liff/v1/apps", request).ConfigureAwait(false);

            return result["liffId"].GetValue<string>();
        }

        /// <summary>
        /// Partially updates LIFF app settings.
        /// </summary>
        /// <param name="liffId">ID of the LIFF app to be updated</param>
        /// <param name="view"></param>
        /// <param name="description">Name of the LIFF app.</param>
        /// <param name="features"></param>
        /// <param name="permanentLinkPattern"></param>
        /// <param name="scope"></param>
        /// <param name="botPrompt"></param>
        /// <returns></returns>
        public async Task UpdateLiffAppSettingAsync(string liffId,
                                                    View view,
                                                    string? description = null,
                                                    Features? features = null,
                                                    string? permanentLinkPattern = null,
                                                    IList<ScopeType>? scope = null,
                                                    BotPromptType? botPrompt = null)
        {
            var request = new LiffApp()
            {
                View = view,
                Description = description,
                Features = features,
                PermanentLinkPattern = permanentLinkPattern,
                Scope = scope,
                BotPrompt = botPrompt
            };

            await base.PutAsync<LiffApp>($"liff/v1/apps/{liffId}", request).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information on all the LIFF apps added to the channel.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<LiffAppInformation>> GetAllLiffAppsAsync()
        {
            var result = await base.GetAsync<LiffApps>("liff/v1/apps", getResponseHeaders:null).ConfigureAwait(false);
            return result.Apps;
        }

        /// <summary>
        /// Deletes a LIFF app from a channel.
        /// </summary>
        /// <param name="liffId">ID of the LIFF app to be deleted</param>
        /// <returns></returns>
        public async Task DeleteLiffAppsFromChannelAsync(string liffId)
            => await base.DeleteAsync($"liff/v1/apps/{liffId}").ConfigureAwait(false);
    }
}
