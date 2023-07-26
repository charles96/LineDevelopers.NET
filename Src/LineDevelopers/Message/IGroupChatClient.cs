using System.Net.Http.Headers;

namespace Line.Message
{
    public interface IGroupChatClient
    {
        /// <summary>
        /// Gets the group ID, group name, and group icon URL of a group chat where the LINE Official Account is a member.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<GroupChatSummary> GetSummaryAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Gets the count of users in a group chat. You can get the user in group count even if the user hasn't added the LINE Official Account as a friend or has blocked the LINE Official Account.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<int> GetNumberOfUsersAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Gets the user IDs of the members of a group chat that the LINE Official Account is in. This includes user IDs of users who have not added the LINE Official Account as a friend or has blocked the LINE Official Account.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<GroupChatMemberUserIDs> GetMemberUserIdsAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Gets the user IDs of the members of a group chat that the LINE Official Account is in. This includes user IDs of users who have not added the LINE Official Account as a friend or has blocked the LINE Official Account.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="start">Value of the continuation token found in the Next property</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<GroupChatMemberUserIDs> GetMemberUserIdsAsync(string groupId, string start, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Gets the profile information of a member of a group chat that the LINE Official Account is in if the user ID of the group member is known.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="userId">User ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<GroupChatMemberProfile> GetChatMemberProfileAsync(string groupId, string userId, Action<HttpResponseHeaders>? getResponseHeaders = null);
        public Task LeaveAsync(string groupId, Action<HttpResponseHeaders>? getResponseHeaders = null);
    }
}
