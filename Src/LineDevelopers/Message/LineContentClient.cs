using System.Net.Http.Headers;
using System.Text.Json;

namespace Line.Message
{
    public class LineContentClient : LineHttpClient
    {
        public LineContentClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { }

        internal LineContentClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        public async Task<Stream> GetContentAsync(string messageId, Action<HttpContentHeaders, HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetStreamAsync($"https://api-data.line.me/v2/bot/message/{messageId}/content", getResponseHeaders).ConfigureAwait(false);
    }
}
