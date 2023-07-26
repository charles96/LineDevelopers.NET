namespace LineDevelopers.Tests
{
    [TestFixture]
    public class LineGroupChatClientTest : BaseTest
    {
        [Test]
        public void GetSummaryAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.GroupChat.GetSummaryAsync(GROUP_CHAT_ID,
                    (o) => 
                    {
                        IEnumerable<string> xLineRequestId;

                        if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                        {
                            That(xLineRequestId.First(), Is.Not.Null);
                            That(xLineRequestId.First(), Is.Not.Empty);
                        }
                    });

                That(result.GroupName, Is.EqualTo("ㅇㅇ"));
                That(result.GroupId, Is.EqualTo(GROUP_CHAT_ID));
            });
        }

        [Test]
        public void GetNumberOfUsersAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.GroupChat.GetNumberOfUsersAsync(GROUP_CHAT_ID,
                    (o) =>
                    {
                        IEnumerable<string> xLineRequestId;

                        if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                        {
                            That(xLineRequestId.First(), Is.Not.Null);
                            That(xLineRequestId.First(), Is.Not.Empty);
                        }
                    });

                That(result, Is.EqualTo(2), $"{result}");
            });
        }

        [Test]
        [Ignore("유료 사용만 가능한 듯")]
        public void GetMemberUserIdsAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.GroupChat.GetMemberUserIdsAsync(GROUP_CHAT_ID,
                    (o) =>
                    {
                        IEnumerable<string> xLineRequestId;

                        if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                        {
                            That(xLineRequestId.First(), Is.Not.Null);
                            That(xLineRequestId.First(), Is.Not.Empty);
                        }
                    });

                That(result.MemberIds.Count, Is.EqualTo(2), $"{result.MemberIds.Count}");
            });
        }

        [Test]
        public void GetChatMemberProfileAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.GroupChat.GetChatMemberProfileAsync(GROUP_CHAT_ID,USER_ID,
                    (o) =>
                    {
                        IEnumerable<string> xLineRequestId;

                        if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                        {
                            That(xLineRequestId.First(), Is.Not.Null);
                            That(xLineRequestId.First(), Is.Not.Empty);
                        }
                    });

                That(result.DisplayName, Is.EqualTo("Charles"), $"{result.DisplayName}");
                That(result.UserId, Is.EqualTo(USER_ID), $"{result.UserId}");
            });
        }

        [Test]
        [Ignore("tested")]
        public void LeaveAsyncTest()
        {
            DoesNotThrowAsync(async () => 
            { 
                await _client.GroupChat.LeaveAsync(GROUP_CHAT_ID, (o) =>
                {
                    IEnumerable<string> xLineRequestId;

                    if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                    {
                        That(xLineRequestId.First(), Is.Not.Null);
                        That(xLineRequestId.First(), Is.Not.Empty);
                    }
                });
            });
        }
    }
}
