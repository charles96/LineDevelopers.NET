using System.Text.Json;
using System.Text.Json.Nodes;

namespace Line.Message
{
    public class LineGroupChatClient : LineHttpClient, IGroupChatClient
    {
        public LineGroupChatClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { }

        internal LineGroupChatClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        public async Task<GroupChatSummary> GetSummaryAsync(string groupId)
            => await base.GetAsync<GroupChatSummary>($"v2/bot/group/{groupId}/summary").ConfigureAwait(false);

        public async Task<int> GetNumberOfUsersAsync(string groupId)
        {
            var result = await base.GetAsync<JsonNode>($"v2/bot/group/{groupId}/members/count").ConfigureAwait(false);
            return result["count"].GetValue<int>();
        }

        public async Task<GroupChatMemberUserIDs> GetMemberUserIdsAsync(string groupId)
            => await base.GetAsync<GroupChatMemberUserIDs>($"v2/bot/group/{groupId}/members/ids").ConfigureAwait(false);

        public async Task<GroupChatMemberUserIDs> GetMemberUserIdsAsync(string groupId, string start)
            => await base.GetAsync<GroupChatMemberUserIDs>($"v2/bot/group/{groupId}/members/ids?start={start}").ConfigureAwait(false);

        public async Task<GroupChatMemberProfile> GetChatMemberProfileAsync(string groupId, string userId)
            => await base.GetAsync<GroupChatMemberProfile>($"v2/bot/group/{groupId}/member/{userId}").ConfigureAwait(false);

        public async Task LeaveAsync(string groupId)
            => await base.PostAsync($"v2/bot/group/{groupId}/leave").ConfigureAwait(false);
    }
}
