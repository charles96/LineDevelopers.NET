using System.Net.Http.Headers;
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

        public async Task<GroupChatSummary> GetSummaryAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<GroupChatSummary>($"v2/bot/group/{groupId}/summary", getResponseHeaders).ConfigureAwait(false);

        public async Task<int> GetNumberOfUsersAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var result = await base.GetAsync<JsonNode>($"v2/bot/group/{groupId}/members/count", getResponseHeaders).ConfigureAwait(false);
            return result["count"].GetValue<int>();
        }

        public async Task<GroupChatMemberUserIDs> GetMemberUserIdsAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<GroupChatMemberUserIDs>($"v2/bot/group/{groupId}/members/ids", getResponseHeaders).ConfigureAwait(false);

        public async Task<GroupChatMemberUserIDs> GetMemberUserIdsAsync(string groupId, string start, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<GroupChatMemberUserIDs>($"v2/bot/group/{groupId}/members/ids?start={start}", getResponseHeaders).ConfigureAwait(false);

        public async Task<GroupChatMemberProfile> GetChatMemberProfileAsync(string groupId, string userId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<GroupChatMemberProfile>($"v2/bot/group/{groupId}/member/{userId}", getResponseHeaders).ConfigureAwait(false);

        public async Task LeaveAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.PostAsync($"v2/bot/group/{groupId}/leave", getResponseHeaders).ConfigureAwait(false);
    }
}
