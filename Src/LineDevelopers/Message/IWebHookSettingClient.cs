using System.Net.Http.Headers;

namespace Line.Message
{
    public interface IWebHookSettingClient
    {
        /// <summary>
        /// Sets the webhook endpoint URL. 
        /// It may take up to 1 minute for changes to take place due to caching.
        /// </summary>
        /// <param name="endpoint">A valid webhook URL.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task SetEndpointUrlAsync(string endpoint, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Gets information on a webhook endpoint.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<WebhookInformation> GetEndpointInformationAsync(Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Checks if the configured webhook endpoint can receive a test webhook event.
        /// </summary>
        /// <param name="endpoint">A webhook URL to be validated.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<WebhookTestResult> TestEndpointAsync(string endpoint, Action<HttpResponseHeaders>? getResponseHeaders = null);
    }
}
