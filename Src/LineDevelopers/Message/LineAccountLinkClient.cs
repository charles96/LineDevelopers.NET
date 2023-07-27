using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Line.Message
{
    public class LineAccountLinkClient : LineHttpClient, IAccountLinkClient
    {
        public LineAccountLinkClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { }

        internal LineAccountLinkClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        /// <summary>
        /// Issues a link token used for the account link feature.
        /// </summary>
        /// <param name="userId">User ID for the LINE account to be linked.</param>
        /// <param name="getResponseHeaders">Response headers</param>
        /// <returns></returns>
        public async Task<string> IssueLinkTokenAsync(string userId, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var result = await base.PostAsJsonAsync<HttpContent,JsonNode>($"v2/bot/user/{userId}/linkToken", null, getResponseHeaders).ConfigureAwait(false);
            return result["linkToken"].GetValue<string>();
        }
    }
}
