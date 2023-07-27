using System.Net.Http.Headers;
using System.Text.Json;

namespace Line.Message
{
    public class LineUserClient : LineHttpClient, IUserClient
    {
        public LineUserClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { }

        internal LineUserClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        /// <summary>
        /// You can get the profile information of users who meet one of two conditions:
        /// Users who have added your LINE Official Account as a friend
        /// Users who haven't added your LINE Official Account as a friend but have sent a message to your LINE Official Account (except users who have blocked your LINE Official Account)
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<UserProfile> GetUserProfileAsync(string userId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<UserProfile>($"v2/bot/profile/{userId}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Gets the list of User IDs of users who have added your LINE Official Account as a friend.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<Followers> GetFollowersAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<Followers>($"v2/bot/followers/ids",getResponseHeaders).ConfigureAwait(false);

    }
}
