namespace Line.Message
{
    public interface IWebHookSettingClient
    {
        public Task SetEndpointUrlAsync(string endpoint);
        public Task<WebhookInformation> GetEndpointInformationAsync();
        public Task<WebhookTestResult> TestEndpointAsync(string endpoint);
    }
}
