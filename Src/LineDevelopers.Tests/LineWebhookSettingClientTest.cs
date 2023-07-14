namespace LineDevelopers.Tests
{
    [TestFixture]
    public class LineWebhookSettingClientTest : BaseTest
    {
        string _endpoint;

        [Test, Order(1)]
        public void GetWebhookTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.WebhookSetting.GetEndpointInformationAsync();

                _endpoint = result.Endpoint;

                That(true, Is.EqualTo(result.Active));
            });
        }

        [Test, Order(2)]
        public async Task SetWebhookTest()
        {
            DoesNotThrowAsync(async () => await _client.WebhookSetting.SetEndpointUrlAsync(_endpoint));
        }

        [Test, Order(3)]
        public void TestWebhookTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.WebhookSetting.TestEndpointAsync(_endpoint);

                That(result.Success, Is.EqualTo(true), $"{result.Success}");
            });
        }
    }
}
