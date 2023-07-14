global using NUnit.Framework;
global using static NUnit.Framework.Assert;
using System.Text.Json;
using Line.Message;

namespace LineDevelopers.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected readonly string CHANNEL_ACCESS_TOKEN;
        protected readonly string USER_ID;
        protected readonly string CHANNEL_ID;
        protected readonly string CHANNEL_SECRET;
        protected readonly string GROUP_CHAT_ID;

        protected LineMessagingClient _client;

        public BaseTest()
        {
            var json = File.ReadAllText(@"c:\temp\test.json");
            var config = JsonSerializer.Deserialize<TestConfig>(json);

            CHANNEL_ACCESS_TOKEN = config.ChannelAccessToken;
            USER_ID = config.UserID;
            CHANNEL_ID = config.ChannelId;
            CHANNEL_SECRET = config.ChannelSecret;
            GROUP_CHAT_ID = config.GroupChatId;
        }

        [OneTimeSetUp]
        public void Initialize()
            => _client = new LineMessagingClient(CHANNEL_ACCESS_TOKEN);

        [OneTimeTearDown]
        public void EndTest()
            => _client?.Dispose();
    }
}
