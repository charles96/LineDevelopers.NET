using Line;

namespace LineDevelopers.Tests
{
    public class LineAccountLinkClientTest : BaseTest
    {
        [Test]
        [Description("invalid user id test")]
        public async Task IssuLinkTokenWithInvalidParamTest()
        {
            var ex = ThrowsAsync<LineException>(() => _client.AccountLink.IssueLinkTokenAsync("fdsafdsa"));

            That("The value for the 'userId' parameter is invalid", Is.EqualTo(ex.Message), $"{ex.Message}");
        }

        [Test]
        public async Task IssuLinkTokenWithInvalidParamWithXLineRequestIdTest()
        {
            var ex = ThrowsAsync<LineException>(async() => 
            { 
                await _client.AccountLink.IssueLinkTokenAsync("fdsafdsa", 
                    getResponseHeaders:(o) =>
                    {
                        IEnumerable<string> xLineRequestId;

                        if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                        {
                            That(xLineRequestId.First(), Is.Not.Null);
                            That(xLineRequestId.First(), Is.Not.Empty);
                        }
                    }); 
            });

            That("The value for the 'userId' parameter is invalid", Is.EqualTo(ex.Message), $"{ex.Message}");
        }

        [Test]
        public void IssuLinkTokenTest()
        {
            DoesNotThrowAsync(async () => 
            {
                var result = await _client.AccountLink.IssueLinkTokenAsync(USER_ID);

                IsNotEmpty(result,result);
            });
        }
    }
}
