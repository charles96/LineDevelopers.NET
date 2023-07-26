using System.Net.Http.Headers;

namespace Line.Message
{
    public interface IUserClient
    {
        /// <summary>
        /// You can get the profile information of users who meet one of two conditions:
        /// Users who have added your LINE Official Account as a friend
        /// Users who haven't added your LINE Official Account as a friend but have sent a message to your LINE Official Account (except users who have blocked your LINE Official Account)
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<UserProfile> GetUserProfileAsync(string userId, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Gets the list of User IDs of users who have added your LINE Official Account as a friend.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<Followers> GetFollowersAsync(Action<HttpResponseHeaders>? getResponseHeaders = null);
    }
}
