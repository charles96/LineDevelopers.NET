using System.Net.Http.Headers;
using System.Text.Json;

namespace Line.Login
{
    internal class LineOAuth2dot1Client : LineHttpClient, IOAuth2dot1Client
    {
        internal LineOAuth2dot1Client(double timeout = 100d)
            : base(timeout)
        { }

        internal LineOAuth2dot1Client(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineCredentialAsync().ConfigureAwait(false);

        /// <summary>
        /// Issues access tokens.
        /// </summary>
        /// <param name="authorizationCode">Authorization code received from the LINE Platform</param>
        /// <param name="redirectUri">redirect uri</param>
        /// <param name="clientId">Channel ID</param>
        /// <param name="clientSecret">Channel secret</param>
        /// <param name="codeVerifier">A random 43-128 character string consisting of single-byte alphanumeric characters and symbols (e.g. wJKN8qz5t8SSI9lMFhBB6qwNkQBkuPZoCxzRhwLRUo1).</param>
        /// <returns></returns>
        public async Task<AccessTokenInformation> IssueAccessTokenAsync(string authorizationCode, string redirectUri, string clientId, string clientSecret, string? codeVerifier = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", authorizationCode),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            };

            if (!String.IsNullOrWhiteSpace(codeVerifier))
                request.Add(new KeyValuePair<string, string>("code_verifier", codeVerifier));

            return await base.PostAsync<AccessTokenInformation>("oauth2/v2.1/token", new FormUrlEncodedContent(request), getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Verifies if an access token is valid.
        /// </summary>
        /// <param name="accessToken">Access token</param>
        /// <returns></returns>
        public async Task<VerifyAccessToken> VerifyAccessTokenValidityAsync(string accessToken, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<VerifyAccessToken>($"oauth2/v2.1/verify?access_token={accessToken}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Gets a new access token using a refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token corresponding to the access token to be reissued. Valid for up to 90 days after the access token was issued. If the refresh token expires, you must prompt the user to log in again to generate a new access token.</param>
        /// <param name="clientId">Channel ID</param>
        /// <param name="clientSecret">Channel secret</param>
        /// <returns></returns>
        public async Task<RefreshAccessToken> RefreshAccessTokenAsync(string refreshToken, string clientId, string clientSecret, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", refreshToken),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            };

            return await base.PostAsync<RefreshAccessToken>($"v2/oauth/accessToken", new FormUrlEncodedContent(request), getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Invalidates a user's access token.
        /// </summary>
        /// <param name="accessToken">Access token</param>
        /// <param name="clientId">Channel ID</param>
        /// <param name="clientSecret">Channel secret</param>
        /// <returns></returns>
        public async Task RevokeAccessTokenAsync(string accessToken, string clientId, string clientSecret, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("access_token", accessToken),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            };

            await base.PostAsync($"oauth2/v2.1/revoke", new FormUrlEncodedContent(request), getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// ID tokens are JSON web tokens (JWT) with information about the user. It's possible for an attacker to spoof an ID token. Use this call to verify that a received ID token is authentic, meaning you can use it to obtain the user's profile information and email.
        /// </summary>
        /// <param name="idToken">ID token</param>
        /// <param name="clientId">Expected channel ID. Unique identifier for your channel issued by LINE.</param>
        /// <param name="nonce">Use the nonce value provided in the authorization request. Omit if the nonce value was not specified in the authorization request.</param>
        /// <param name="userId">user ID</param>
        /// <returns></returns>
        public async Task<VerifyIdToken> VerifyIdTokenAsync(string idToken, string clientId, string? nonce = null, string? userId = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("id_token", idToken),
                new KeyValuePair<string, string>("client_id", clientId)
            };

            if (!String.IsNullOrWhiteSpace(nonce))
                request.Add(new KeyValuePair<string, string>("nonce", nonce));

            if (!String.IsNullOrWhiteSpace(userId))
                request.Add(new KeyValuePair<string, string>("user_id", userId));

            return await base.PostAsync<VerifyIdToken>($"oauth2/v2.1/verify", new FormUrlEncodedContent(request), getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a user's ID, display name, and profile image.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<UserInformation> GetUserInformationAsync(string accessToken, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<UserInformation>("oauth2/v2.1/userinfo", "Authorization", $"Bearer {accessToken}", getResponseHeaders).ConfigureAwait(false);
    }
}
