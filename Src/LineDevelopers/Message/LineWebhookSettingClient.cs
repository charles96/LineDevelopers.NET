using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Line.Message
{
    public class LineWebhookSettingClient : LineHttpClient, IWebHookSettingClient
    {
        public LineWebhookSettingClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { }

        internal LineWebhookSettingClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        public async Task SetEndpointUrlAsync(string endpoint, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new JsonObject() { ["endpoint"] = endpoint };

            await base.PutAsync($"v2/bot/channel/webhook/endpoint", request, getResponseHeaders).ConfigureAwait(false);
        }

        public async Task<WebhookInformation> GetEndpointInformationAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<WebhookInformation>("v2/bot/channel/webhook/endpoint", getResponseHeaders).ConfigureAwait(false);

        public async Task<WebhookTestResult> TestEndpointAsync(string endpoint, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new JsonObject() { ["endpoint"] = endpoint };

            return await base.PostAsJsonAsync<JsonObject, WebhookTestResult>("v2/bot/channel/webhook/test", request, getResponseHeaders).ConfigureAwait(false);
        }
    }
}
