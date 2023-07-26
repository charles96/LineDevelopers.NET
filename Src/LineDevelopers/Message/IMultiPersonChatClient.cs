using System.Net.Http.Headers;

namespace Line.Message
{
    public interface IMultiPersonChatClient
    {
        /// <summary>
        /// Gets the count of users in a multi-person chat. 
        /// You can get the user in multi-person chat count even if the user hasn't added the LINE Official Account as a friend or has blocked the LINE Official Account.
        /// </summary>
        /// <param name="roomId">Room ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<int> GetNumberOfUsersAsync(string roomId, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Gets the user IDs of the members of a multi-person chat that the LINE Official Account is in. This includes the user IDs of users who have not added the LINE Official Account as a friend or have blocked the LINE Official Account.
        /// </summary>
        /// <param name="roomId">Room ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<MultiPersonChatMemberUserIds> GetMemberUserIdsAsync(string roomId, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Gets the user IDs of the members of a multi-person chat that the LINE Official Account is in. This includes the user IDs of users who have not added the LINE Official Account as a friend or have blocked the LINE Official Account.
        /// </summary>
        /// <param name="roomId">Room ID.</param>
        /// <param name="next">Value of the continuation token found in the next property</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<MultiPersonChatMemberUserIds> GetMemberUserIdsAsync(string roomId, string next, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Gets the profile information of a member of a multi-person chat that the LINE Official Account is in if the user ID of the multi-person chat member is known.
        /// </summary>
        /// <param name="roomId">Room ID.</param>
        /// <param name="userId">User ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<MultiPersonChatMemberProfile> GetMemberProfileAsync(string roomId, string userId, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Leaves a multi-person chat.
        /// </summary>
        /// <param name="roomId">Room ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task LeaveAsync(string roomId, Action<HttpResponseHeaders>? getResponseHeaders = null);
    }
}
