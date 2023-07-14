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

        public async Task<string> IssueLinkTokenAsync(string userId)
        {
            var result = await base.PostAsJsonAsync<HttpContent,JsonNode>($"v2/bot/user/{userId}/linkToken", null).ConfigureAwait(false);
            return result["linkToken"].GetValue<string>();
        }
    }
}
