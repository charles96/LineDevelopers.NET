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
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserProfile> GetUserProfileAsync(string userId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<UserProfile>($"v2/bot/profile/{userId}", getResponseHeaders).ConfigureAwait(false);

        public async Task<Followers> GetFollowersAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<Followers>($"v2/bot/followers/ids",getResponseHeaders).ConfigureAwait(false);

    }
}
