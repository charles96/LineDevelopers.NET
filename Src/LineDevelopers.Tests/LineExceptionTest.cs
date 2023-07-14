using Line;
using Line.Message;

namespace LineDevelopers.Tests
{
    [TestFixture]
    public class LineExceptionTest : BaseTest
    {
        [Test]
        public async Task ValidateMessageReplyTest()
        {
            List<IMessage> request = new List<IMessage>()
            {
                new TextMessage()
                { 
                    Text = ""
                },
                new StickerMessage()
                { 
                    PackageId = "",
                    StickerId = ""
                }
            };
                        
            var ex = ThrowsAsync<LineException>(() => _client.Message.ValidateMessageObjectsOfMessageAsync(SendType.Reply, request));

            That(ex.Message, Is.EqualTo("The request body has 3 error(s)"));
            That(ex.Details[0].Message, Is.EqualTo("May not be empty"));
            That(ex.Details[0].Property, Is.EqualTo("messages[0].text"));
        }

        [Test]
        public async Task SendReplyTokenErrorTest()
        {
            List<IMessage> request = new List<IMessage>()
            {
                new TextMessage()
                {
                    Text = "dddd"
                }
            };

            var ex = ThrowsAsync<LineException>(() => _client.Message.SendReplyMessageAsync("dfdasfd", request));

            That(ex.Message, Is.EqualTo("Invalid reply token"),$"{ex.Message}");
        }

        [Test]
        public void InvalidXLineRetryKeyTest()
        {
            var ex = ThrowsAsync<LineException>(() => _client.Message.SendPushMessageAsync(USER_ID, new TextMessage("invalid xLine Test"), xLineRetryKey: "DUMMY"));

            That(ex.Message, Is.EqualTo("The value for the 'X-Line-Retry-Key' parameter is invalid"), $"{ex.Message}");
        }

        [Test]
        public void IssueChannelAccessTokenErrorTest()
        {
            var ex = ThrowsAsync<LineCredentialException>(async () => 
            { 
                LineChannelAccessTokenClient client = new LineChannelAccessTokenClient();

                await client.IssueChannelAccessTokenAsync("DUMMY");
            });

            That(ex.Message, Is.EqualTo("invalid_client"), $"{ex.Message}");
            That(ex.Detail, Is.EqualTo("JWT format error"), $"{ex.Detail}");
        }

        [Test]
        public void DisposeTest()
        {
            var client = new LineMessagingClient(CHANNEL_ACCESS_TOKEN);

            DoesNotThrowAsync(() => client.Users.GetUserProfileAsync(USER_ID));
            DoesNotThrowAsync(() => client.Insight.GetFriendsDemographicsAsync());
            DoesNotThrow(() => client.Dispose());
            ThrowsAsync<ObjectDisposedException>(() => client.Insight.GetFriendsDemographicsAsync());
        }
    }
}
