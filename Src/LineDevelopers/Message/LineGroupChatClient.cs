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

        /// <summary>
        /// Gets the group ID, group name, and group icon URL of a group chat where the LINE Official Account is a member.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<GroupChatSummary> GetSummaryAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<GroupChatSummary>($"v2/bot/group/{groupId}/summary", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Gets the count of users in a group chat. You can get the user in group count even if the user hasn't added the LINE Official Account as a friend or has blocked the LINE Official Account.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<int> GetNumberOfUsersAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var result = await base.GetAsync<JsonNode>($"v2/bot/group/{groupId}/members/count", getResponseHeaders).ConfigureAwait(false);
            return result["count"].GetValue<int>();
        }

        /// <summary>
        /// Gets the user IDs of the members of a group chat that the LINE Official Account is in. This includes user IDs of users who have not added the LINE Official Account as a friend or has blocked the LINE Official Account.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<GroupChatMemberUserIDs> GetMemberUserIdsAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<GroupChatMemberUserIDs>($"v2/bot/group/{groupId}/members/ids", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Gets the user IDs of the members of a group chat that the LINE Official Account is in. This includes user IDs of users who have not added the LINE Official Account as a friend or has blocked the LINE Official Account.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="start">Value of the continuation token found in the Next property</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<GroupChatMemberUserIDs> GetMemberUserIdsAsync(string groupId, string start, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<GroupChatMemberUserIDs>($"v2/bot/group/{groupId}/members/ids?start={start}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Gets the profile information of a member of a group chat that the LINE Official Account is in if the user ID of the group member is known.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="userId">User ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<GroupChatMemberProfile> GetChatMemberProfileAsync(string groupId, string userId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<GroupChatMemberProfile>($"v2/bot/group/{groupId}/member/{userId}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Leaves a group chat.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task LeaveAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.PostAsync($"v2/bot/group/{groupId}/leave", getResponseHeaders).ConfigureAwait(false);
    }
}
