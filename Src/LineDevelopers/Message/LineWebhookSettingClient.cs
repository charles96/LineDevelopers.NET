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

        /// <summary>
        /// Sets the webhook endpoint URL. 
        /// It may take up to 1 minute for changes to take place due to caching.
        /// </summary>
        /// <param name="endpoint">A valid webhook URL.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SetEndpointUrlAsync(string endpoint, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new JsonObject() { ["endpoint"] = endpoint };

            await base.PutAsync($"v2/bot/channel/webhook/endpoint", request, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information on a webhook endpoint.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<WebhookInformation> GetEndpointInformationAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<WebhookInformation>("v2/bot/channel/webhook/endpoint", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Checks if the configured webhook endpoint can receive a test webhook event.
        /// </summary>
        /// <param name="endpoint">A webhook URL to be validated.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<WebhookTestResult> TestEndpointAsync(string endpoint, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new JsonObject() { ["endpoint"] = endpoint };

            return await base.PostAsJsonAsync<JsonObject, WebhookTestResult>("v2/bot/channel/webhook/test", request, getResponseHeaders).ConfigureAwait(false);
        }
    }
}
