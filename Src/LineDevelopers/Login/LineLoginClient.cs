using System.Text.Json.Nodes;

namespace Line.Login
{
    public class LineLoginClient : LineHttpClient
    {
        IOAuth2dot1Client oAuth2dot1Client;

        public LineLoginClient(double timeout = 100d)
            : base(timeout)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        /// <summary>
        /// Line Login v2.1
        /// </summary>
        public IOAuth2dot1Client OAuth2dot1 => oAuth2dot1Client ??= new LineOAuth2dot1Client(base._httpClient, base._jsonSerializerOptions);

        /// <summary>
        /// Gets a user's ID, display name, profile image, and status message.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<UserProfile> GetUserProfileAsync(string accessToken)
            => await base.GetAsync<UserProfile>("v2/profile", "Authorization", $"Bearer {accessToken}").ConfigureAwait(false);

        /// <summary>
        /// Gets the friendship status between a user and the LINE Official Account linked to your LINE Login channel.
        /// </summary>
        /// <param name="accessToken">access token</param>
        /// <returns></returns>
        public async Task<bool> GetFriendshipStatusAsync(string accessToken)
        {
            var result = await base.GetAsync<JsonNode>("friendship/v1/status", "Authorization", $"Bearer {accessToken}").ConfigureAwait(false);

            return result["friendFlag"].GetValue<bool>();
        }
    }
}
