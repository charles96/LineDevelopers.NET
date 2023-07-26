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
                var result = await _client.WebhookSetting.GetEndpointInformationAsync(getResponseHeaders: (o) =>
                {
                    IEnumerable<string> xLineRequestId;

                    if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                    {
                        That(xLineRequestId.First(), Is.Not.Null);
                        That(xLineRequestId.First(), Is.Not.Empty);
                    }
                });

                _endpoint = result.Endpoint;

                That(true, Is.EqualTo(result.Active));
            });
        }

        [Test, Order(2)]
        public async Task SetWebhookTest()
        {
            DoesNotThrowAsync(async () => await _client.WebhookSetting.SetEndpointUrlAsync(_endpoint, getResponseHeaders: (o) =>
            {
                IEnumerable<string> xLineRequestId;

                if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                {
                    That(xLineRequestId.First(), Is.Not.Null);
                    That(xLineRequestId.First(), Is.Not.Empty);
                }
            }));
        }

        [Test, Order(3)]
        public void TestWebhookTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.WebhookSetting.TestEndpointAsync(_endpoint, getResponseHeaders: (o) =>
                {
                    IEnumerable<string> xLineRequestId;

                    if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                    {
                        That(xLineRequestId.First(), Is.Not.Null);
                        That(xLineRequestId.First(), Is.Not.Empty);
                    }
                });

                That(result.Success, Is.EqualTo(true), $"{result.Success}");
            });
        }
    }
}
