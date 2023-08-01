using Line;
using Line.Message;

namespace LineDevelopers.Tests
{
    [TestFixture]
    public class LineInsightClientTest : BaseTest
    {
        [Test]
        [Description("기간이 지난 것 검색 시")]
        public async Task GetNumberOfMessageDeliveriesAsync()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.Insight.GetNumberOfMessageDeliveriesAsync(new DateOnly(1977, 10, 31));

                That(result.Status, Is.EqualTo(CalculationStatus.OutOfService));
            });
        }

        [Test]
        public void GetUserInteractionStatisticsAsyncErrorTest()
        {
            var ex = ThrowsAsync<LineException>(() => _client.Insight.GetUserInteractionStatisticsAsync("NOT EXISTS REQ ID"));

            That("Not Found", Is.EqualTo(ex.Message));
        }

        [Test]
        public void GetUserInteractionStatisticsAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                string requestId = String.Empty;

                await _client.Message.SendBroadcastMessageAsync(new TextMessage("static test"),
                        getResponseHeaders: async (o) =>
                        {
                            IEnumerable<string> xLineRequestId;

                            if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                            {
                                requestId = xLineRequestId.First();
                            }
                        });
                
                await Task.Delay(10000);

                var result = await _client.Insight.GetUserInteractionStatisticsAsync(requestId);

                That(result.Overview.RequestId, Is.EqualTo(requestId),$"err : {result.Overview.RequestId} : {requestId}");
            });
        }

        [Test]
        public void GetStatisticsPerUnitAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.Insight.GetStatisticsPerUnitAsync("Promotion_TEST", new DateOnly(2023, 7, 31), new DateOnly(2023, 7, 31));
                
                That(result.Messages.Count, Is.EqualTo(2));
            });
        }


        [Test]
        public void GetNumberOfFollowersAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var currentTime = DateTime.Now;

                var result = await _client.Insight.GetNumberOfFollowersAsync(new DateOnly(currentTime.Year, currentTime.Month, currentTime.Day));
            
                GreaterOrEqual(result.Followers, 1);
            });
        }

        [Test]
        public void GetFriendsDemographicsAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.Insight.GetFriendsDemographicsAsync();

                That(result.Available, Is.EqualTo(false));
            });
        }
    }
}