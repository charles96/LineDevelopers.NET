using Line.Message;

namespace LineDevelopers.Tests
{
    [TestFixture]
    public class LineBotClientTest : BaseTest
    {
        [Test]
        public void GetBotInformationAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await base._client.Bot.GetBotInformationAsync();

                That(result.DisplayName, Is.EqualTo("Atom"));
                That(result.MarkAsReadMode, Is.EqualTo(ReadType.Auto));
                That(result.ChatMode, Is.EqualTo(ChatType.Bot));
            });
        }

        [Test]
        public void GetBotInformationAsyncWithXLineRequestIdTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await base._client.Bot.GetBotInformationAsync((o) => 
                {
                    IEnumerable<string> xLineRequestId;

                    if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                    {
                        That(xLineRequestId.First(), Is.Not.Null);
                        That(xLineRequestId.First(), Is.Not.Empty);
                    }
                });

                That(result.DisplayName, Is.EqualTo("Atom"));
                That(result.MarkAsReadMode, Is.EqualTo(ReadType.Auto));
                That(result.ChatMode, Is.EqualTo(ChatType.Bot));
            });
        }

    }
}
