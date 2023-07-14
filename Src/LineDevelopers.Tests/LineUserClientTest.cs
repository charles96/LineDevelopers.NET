namespace LineDevelopers.Tests
{
    [TestFixture]
    internal class LineUserClientTest : BaseTest
    {
        [Test]
        public void GetBotInformationAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await base._client.GetBotInformationAsync();

                AreEqual(result.DisplayName, "Atom");
            });
        }

        [Test]
        public void GetUserProfileAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await base._client.Users.GetUserProfileAsync(USER_ID);

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
                var result = await base._client.Users.GetFollowersAsync();
                GreaterOrEqual(result.Message.Count(), 1, $"{result.Message.Count()}");
            });
        }
    }
}
