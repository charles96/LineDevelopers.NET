using Line;
using Line.Message;

namespace LineDevelopers.Tests
{
    [TestFixture]
    public class LineRichMenuClientTest : BaseTest
    {
        string _richMenuId;
        string _richMenuId2;

        public RichMenuObject MockRichMenu(string mockName)
        {
            #region arrange
            return new RichMenuObject()
            {
                Size = new RichMenuSizeObject()
                {
                    Width = 2500,
                    Height = 1686
                },
                Selected = false,
                Name = mockName,
                ChatBarText = "Tap to open",
                Areas = new List<RichMenuAreaObject>()
                {
                    new RichMenuAreaObject()
                    {
                        Bounds = new RichMenuBoundsObject()
                        {
                            X = 34,
                            Y = 24,
                            Width = 169,
                            Height = 193
                        },
                        Action = new UriAction()
                        {
                            Uri = "https://developers.line.biz/en/news/"
                        }
                    },
                    new RichMenuAreaObject()
                    {
                        Bounds = new RichMenuBoundsObject()
                        {
                            X = 229,
                            Y = 24,
                            Width = 207,
                            Height = 193
                        },
                        Action = new UriAction()
                        {
                            Uri = "https://www.line-community.me/en/"
                        }
                    },
                    new RichMenuAreaObject()
                    {
                        Bounds = new RichMenuBoundsObject()
                        {
                            X = 461,
                            Y = 24,
                            Width = 173,
                            Height = 193
                        },
                        Action = new UriAction()
                        {
                            Uri = "https://engineering.linecorp.com/en/blog/"
                        }
                    }
                }
            };
            #endregion
        }

        [Test, Order(1)]
        [Description("validation richmenu")]
        public void ValidationTest()
        {
            DoesNotThrowAsync(() => _client.RichMenu.ValidateRichMenuAsync(MockRichMenu("MOCK1")));
        }

        [Test, Order(2)]
        [Description("create richmenu")]
        public async Task CreateTest()
        {
            var request = MockRichMenu("MOCK1");

            DoesNotThrowAsync(async () =>
            {
                var result = await _client.RichMenu.CreateRichMenuAsync(request);
                _richMenuId = result;

                IsNotEmpty(result);
            });
        }

        [Test, Order(3)]
        public async Task GetRichMenuAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.RichMenu.GetRichMenuAsync(_richMenuId);

                That(_richMenuId, Is.EqualTo(result.RichMenuId));
            });
        }

        [Test, Order(4)]
        public async Task UploadRichMenuImageTest()
        {
            DoesNotThrowAsync(() => _client.RichMenu.UploadRichMenuImageAsync(_richMenuId, @"c:\Temp\png.jpg", MediaType.Jpg));
        }

        [Test, Order(5)]
        public async Task DownloadRichMenuImageAsyncTest()
        {
            DoesNotThrowAsync(() => _client.RichMenu.DownloadRichMenuImageAsync(_richMenuId, @"c:\Te2mp\222.jpg"));
        }

        [Test, Order(6)]
        public void GetRichMenuListAsyncTest()
        {
            DoesNotThrowAsync(async () => {

                var richmenu = MockRichMenu("MOCK1");

                var result = await _client.RichMenu.GetRichMenuListAsync();

                GreaterOrEqual(result.Count(), 1, $"{result.Count()}");
                That(result[0].Name, Is.EqualTo(richmenu.Name));
            });
        }

        [Test, Order(7)]
        [Description("not exist default richmenu test")]
        public void GetDefaultRichMenuIdAsync1Test()
        {
            var ex = ThrowsAsync<LineException>(() => _client.RichMenu.GetDefaultRichMenuIdAsync());

            That(ex.Message, Is.EqualTo("no default richmenu"), $"{ex.Message}");
        }

        [Test, Order(8)]
        public void SetDefaultRichMenuAsyncTest()
        {
            DoesNotThrowAsync(async () => {
                await _client.RichMenu.SetDefaultRichMenuAsync(_richMenuId);
            });
        }

        [Test, Order(9)]
        public void GetDefaultRichMenuIdAsync2Test()
        {
            DoesNotThrowAsync(async () => {

                var result = await _client.RichMenu.GetDefaultRichMenuIdAsync();

                That(result, Is.EqualTo(_richMenuId));
            });
        }

        [Test, Order(10)]
        public void CancelDefaultRichMenuAsyncTest()
        {
            DoesNotThrowAsync(async () => {
                await _client.RichMenu.CancelDefaultRichMenuAsync();
            });
        }

        [Test, Order(11)]
        public void CreateRichMenuAliasAsyncTest()
        {
            DoesNotThrowAsync(async () => {
                await _client.RichMenu.CreateRichMenuAliasAsync(_richMenuId, "charles_rich");
            });
        }

        [Test, Order(12)]
        public void UpdateRichMenuAliasAsyncTest()
        {
            DoesNotThrowAsync(async () => {
                await _client.RichMenu.UpdateRichMenuAliasAsync(_richMenuId, "charles_rich");
            });
        }

        [Test, Order(13)]
        public void GetRichMenuAliasInformationAsyncTest()
        {
            DoesNotThrowAsync(async () => {
                var result = await _client.RichMenu.GetRichMenuAliasInformationAsync("charles_rich");

                That(result.RichMenuId, Is.EqualTo(_richMenuId));
                That(result.RichMenuAliasId, Is.EqualTo("charles_rich"));
            });
        }

        [Test, Order(14)]
        public void GetListOfRichMenuAliasAsyncTest()
        {
            DoesNotThrowAsync(async () => {
                var result = await _client.RichMenu.GetListOfRichMenuAliasAsync();

                That(result[0].RichMenuId, Is.EqualTo(_richMenuId));
                That(result[0].RichMenuAliasId, Is.EqualTo("charles_rich"));
            });
        }

        [Test, Order(15)]
        public void DeleteRichMenuAliasAsyncTest()
        {
            DoesNotThrowAsync(async () => {
                await _client.RichMenu.DeleteRichMenuAliasAsync("charles_rich");
            });
        }

        [Test, Order(16)]
        public void LinkRichMenuToUserAsyncTest()
        {
            DoesNotThrowAsync(async () => {
                await _client.RichMenu.LinkRichMenuToUserAsync(USER_ID, _richMenuId);
            });
        }

        [Test, Order(17)]
        public void GetRichMenuIdOfUserAsyncTest()
        {
            DoesNotThrowAsync(async () => {

                var result = await _client.RichMenu.GetRichMenuIdOfUserAsync(USER_ID);

                That(result, Is.EqualTo(_richMenuId));
            });
        }

        [Test, Order(18)]
        public void UnlinkRichMenuFromUserAsyncTest()
        {
            DoesNotThrowAsync(async () => await _client.RichMenu.UnlinkRichMenuFromUserAsync(USER_ID));
        }

        [Test, Order(19)]
        public void LinkRichMenuToMultipleUsersAsyncTest()
        {
            DoesNotThrowAsync(async () => {

                var users = new List<string>() { USER_ID };

                await _client.RichMenu.LinkRichMenuToMultipleUsersAsync(_richMenuId, users);
            });
        }

        [Test, Order(20)]
        public void UnlinkRichMenusFromMultipleUsersAsyncTest()
        {
            DoesNotThrowAsync(async () => {

                var users = new List<string>() { USER_ID };

                await _client.RichMenu.UnlinkRichMenusFromMultipleUsersAsync(users);
            });
        }


        [Test, Order(22)]
        [Description("create richmenu")]
        public async Task CreateMock2Test()
        {
            var request = MockRichMenu("MOCK2");

            DoesNotThrowAsync(async () =>
            {
                var result = await _client.RichMenu.CreateRichMenuAsync(request);
                _richMenuId2 = result;

                IsNotEmpty(result);
            });
        }

        [Test, Order(23)]
        public void ValidateRequestOfRichMenuBatchControlAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var request = new List<RichMenuOperationObject>()
                {
                    new RichMenuOperationObject()
                    {
                        Type = RichMenuOperationType.UnLink,
                        From = _richMenuId,
                        To = _richMenuId2
                    }
                };

                await _client.RichMenu.ValidateRequestOfRichMenuBatchControlAsync(request);
            });
        }

        [Test, Order(24)]
        [Ignore("tested")]
        public void ReplaceOrUnlinkTheLinkedRichMenusInBatchesAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var request = new List<RichMenuOperationObject>()
                {
                    new RichMenuOperationObject()
                    { 
                        Type = RichMenuOperationType.UnLink,
                        From = _richMenuId, 
                        To = _richMenuId2
                    }
                };

                await _client.RichMenu.ReplaceOrUnlinkTheLinkedRichMenusInBatchesAsync(request);
            });
        }

        //[Test, Order(21)]
        //public void GetStatusOfRichMenuBatchControlAsyncTest()
        //{
        //    DoesNotThrowAsync(async () => {

        //        var result = await _client.RichMenu.GetStatusOfRichMenuBatchControlAsync("dd");

        //        That(result.Phase, Is.EqualTo(BatchControlStatus.Succeeded), $"{BatchControlStatus.Succeeded}");
        //    });
        //}


        [Test, Order(25)]
        [Description("delete richmenu")]
        public void DeleteRichMenuAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var menus = await _client.RichMenu.GetRichMenuListAsync();

                foreach (var menu in menus)
                {
                    await _client.RichMenu.DeleteRichMenuAsync(menu.RichMenuId);
                }
            });
        }
    }
}
