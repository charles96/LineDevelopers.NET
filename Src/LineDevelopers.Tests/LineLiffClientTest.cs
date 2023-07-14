using System.Text.Json;
using Line;
using Line.Liff;

namespace LineDevelopers.Tests
{
    [TestFixture]
    public class LineLiffClientTest : BaseTest
    {
        string LIFF_CHANNEL_ACCESS_TOKEN;
        readonly string LIFF_CHANNEL_ID;
        readonly string LIFF_CHANNEL_SECRET;
        string _liffId;
        IList<LiffAppInformation> _liffs;

        LineLiffClient _liffClient;
        LineChannelAccessTokenClient _lineChannelAccessTokenClient;

        public LineLiffClientTest()
        {
            var json = File.ReadAllText(@"c:\temp\test_liff.json");
            var config = JsonSerializer.Deserialize<TestConfig>(json);

            LIFF_CHANNEL_ID = config.ChannelId;
            LIFF_CHANNEL_SECRET = config.ChannelSecret;
        }

        [Test, Order(1)]
        public void GetChannelAccessTokenTest()
        {
            DoesNotThrowAsync(async () =>
            {
                _lineChannelAccessTokenClient = new LineChannelAccessTokenClient();

                var result = await _lineChannelAccessTokenClient.IssueShortLivedChannelAccessTokenAsync(LIFF_CHANNEL_ID, LIFF_CHANNEL_SECRET);
                LIFF_CHANNEL_ACCESS_TOKEN = result.AccessToken;
            });
        }

        [Test, Order(2)]
        public void LIFFInstanceTest()
        {
            DoesNotThrow(() =>
            {
                _liffClient = new LineLiffClient(LIFF_CHANNEL_ACCESS_TOKEN);
            });
        }

        [Test, Order(3)]
        public void AddLiffAppToChannelAsyncTest()
        {
            #region arrange
            View view = new View()
            {
                Type = ViewType.Full,
                Url = "https://lunasoft.co.kr"
            };
            Features features = new Features()
            {
                Ble = true,
                QrCode = true
            };
            List<ScopeType> scope = new List<ScopeType>()
                    {
                        ScopeType.Profile,
                        ScopeType.ChatMessageWrite
                    };
            #endregion

            DoesNotThrowAsync(async() => 
            {
                _liffId = await _liffClient.AddLiffAppToChannelAsync(view, "Description", features, "concat", scope, BotPromptType.None);
            });
        }

        [Test, Order(4)]
        public void UpdateLiffAppSettingAsyncTest()
        {
            #region arrange
            View view = new View()
            {
                Type = ViewType.Tall,
                Url = "https://lunasoft.co.kr"
            };
            Features features = new Features()
            {
                Ble = true,
                QrCode = true
            };
            List<ScopeType> scope = new List<ScopeType>()
                    {
                        ScopeType.Profile,
                        ScopeType.ChatMessageWrite
                    };
            #endregion

            DoesNotThrowAsync(async () =>
            {
                await _liffClient.UpdateLiffAppSettingAsync(_liffId, view, "Update Description", features, "concat", scope, BotPromptType.None);
            });
        }

        [Test, Order(4)]
        public void GetAllLiffAppsAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                _liffs = await _liffClient.GetAllLiffAppsAsync();

                That(_liffs[0].Description, Is.EqualTo("Update Description"));
                That(_liffs[0].View.Type, Is.EqualTo(ViewType.Tall));
            });
        }

        [Test, Order(5)]
        public void DeleteLiffAppsFromChannelAsyncTest()
        {
            DoesNotThrowAsync(async() =>
            {
                foreach (var liff in _liffs)
                {
                    await _liffClient.DeleteLiffAppsFromChannelAsync(liff.LiffId);
                }
            });
        }

        [OneTimeTearDown]
        public void EndTest()
            => _liffClient?.Dispose();

    }
}
