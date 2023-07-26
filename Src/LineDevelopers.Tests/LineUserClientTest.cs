namespace LineDevelopers.Tests
{
    [TestFixture]
    public class LineUserClientTest : BaseTest
    {
        [Test]
        public void GetUserProfileAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await base._client.Users.GetUserProfileAsync(USER_ID, 
                    getResponseHeaders: (o) =>
                {
                    IEnumerable<string> xLineRequestId;

                    if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                    {
                        That(xLineRequestId.First(), Is.Not.Null);
                        That(xLineRequestId.First(), Is.Not.Empty);
                    }
                });

                That(result.DisplayName, Is.EqualTo("Charles"), result.DisplayName);
                IsNotEmpty(result.UserId);
            });
        }

        [Test]
        [Ignore("유료")]
        public void GetFollowersAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await base._client.Users.GetFollowersAsync(getResponseHeaders: (o) =>
                {
                    IEnumerable<string> xLineRequestId;

                    if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                    {
                        That(xLineRequestId.First(), Is.Not.Null);
                        That(xLineRequestId.First(), Is.Not.Empty);
                    }
                });

                GreaterOrEqual(result.Message.Count(), 1, $"{result.Message.Count()}");
            });
        }
    }
}
