using Line;

namespace LineDevelopers.Tests
{
    [TestFixture]
    public class LineChannelAccessTokenClientTest : BaseTest
    {
        ChannelAccessToken _token = null;

        LineChannelAccessTokenClient _lineChannelAccessTokenClient;

        [OneTimeSetUp]
        public void Initialize()
            => _lineChannelAccessTokenClient = new LineChannelAccessTokenClient();

        [OneTimeTearDown]
        public void EndTest()
            => _lineChannelAccessTokenClient?.Dispose();

        [Test,Order(1)]
        public void IssueShortLivedChannelAccessTokenTest()
        {
            DoesNotThrowAsync(async () => _token = await _lineChannelAccessTokenClient.IssueShortLivedChannelAccessTokenAsync(CHANNEL_ID, CHANNEL_SECRET));
        }

        [Test, Order(2)]
        public void VerifyShortLonglivedChannelAccessTokenTest()
        {
            DoesNotThrowAsync(async () => await _lineChannelAccessTokenClient.VerifyShortLonglivedChannelAccessTokenAsync(_token.AccessToken));
        }

        [Test, Order(3)]
        public void RevokeShortLongLivedChannelAccessTokenTest()
        {
            DoesNotThrowAsync(async () => await _lineChannelAccessTokenClient.RevokeShortLongLivedChannelAccessTokenAsync(_token.AccessToken));
        }

        [Test, Order(4)]
        public void VerifyShortLonglivedChannelAccessTokenAsyncTest()
        {
            ThrowsAsync<LineCredentialException>(async () => await _lineChannelAccessTokenClient.VerifyShortLonglivedChannelAccessTokenAsync(_token.AccessToken));
        }

        [Test, Order(5)]
        public void VerifyTheChannelAccessTokenAsyncTest()
        {
            DoesNotThrowAsync(async () => {
                var result = await _lineChannelAccessTokenClient.VerifyChannelAccessTokenAsync(_token.AccessToken);
            });
        }

        [Test, Order(6)]
        public void RevokeChannelAccessTokenAsyncTest()
        {
            DoesNotThrowAsync(async () => {
                await _lineChannelAccessTokenClient.RevokeChannelAccessTokenAsync(CHANNEL_ID, CHANNEL_SECRET,_token.AccessToken);
            });

        }
    }
}
