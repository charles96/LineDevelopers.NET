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
        public void GetUserInteractionStatisticsAsyncTest()
        {
            var ex = ThrowsAsync<LineException>(() => _client.Insight.GetUserInteractionStatisticsAsync("NOT EXISTS REQ ID"));

            That("Not Found", Is.EqualTo(ex.Message));
        }

        [Test]
        public void GetStatisticsPerUnitAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                await _client.Insight.GetStatisticsPerUnitAsync("DUMMY", new DateOnly(2023, 04, 01), new DateOnly(2023, 04, 10));
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