using System.Text.Json;

namespace Line
{
    public class LineChannelAccessTokenClient : LineHttpClient
    {
        public LineChannelAccessTokenClient(double timeout = 100d)
            : base(timeout)
        { }

        internal LineChannelAccessTokenClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineCredentialAsync().ConfigureAwait(false);

        /// <summary>
        /// Issues a channel access token that allows you to specify a desired expiration date. 
        /// This method lets you use JWT assertion for authentication.
        /// You can issue up to 30 tokens per channel for channel access tokens v2.1. 
        /// If you reach the maximum limit, additional requests of issuing channel access tokens are blocked.
        /// </summary>
        /// <param name="clientAssertion"></param>
        /// <returns></returns>
        public async Task<ChannelAccessToken> IssueChannelAccessTokenAsync(string clientAssertion)
        {
            var request = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer"),
                new KeyValuePair<string, string>("client_assertion", clientAssertion)
            };

            return await base.PostAsync<ChannelAccessToken>("oauth2/v2.1/token", new FormUrlEncodedContent(request)).ConfigureAwait(false);
        }

        public async Task<VerifyChannelAccessToken> VerifyChannelAccessTokenAsync(string accessToken)
        {
            var request = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("access_token", accessToken)
            };

            return await base.GetAsync<VerifyChannelAccessToken>($"oauth2/v2.1/verify", new FormUrlEncodedContent(request)).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all valid channel access token key IDs.
        /// </summary>
        /// <param name="clientAssertion">A JSON Web Token (JWT) (opens new window)the client needs to create and sign with the private key.</param>
        /// <returns>Array of channel access token key IDs.</returns>
        public async Task<IList<string>> GetAllValidChannelAccessTokenKeyIDsAsync(string clientAssertion)
        {
            var request = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer"),
                new KeyValuePair<string, string>("client_assertion", clientAssertion)
            };

            var result = await base.GetAsync<AllValidChannelAccessTokenKeyIDs>($"oauth2/v2.1/tokens/kid", new FormUrlEncodedContent(request)).ConfigureAwait(false);

            return result.Kids;
        }

        public async Task RevokeChannelAccessTokenAsync(string clientId, string client_secret, string channelAccessToken)
        {
            var request = new List<KeyValuePair<string, string>> 
            {
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", client_secret),
                new KeyValuePair<string, string>("access_token", channelAccessToken)
            };

            await base.PostAsync($"oauth2/v2.1/revoke", new FormUrlEncodedContent(request)).ConfigureAwait(false);
        }

        public async Task<ChannelAccessToken> IssueShortLivedChannelAccessTokenAsync(string clientId, string clientSecret)
        {
            var request = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            };

            return await base.PostAsync<ChannelAccessToken>($"v2/oauth/accessToken", new FormUrlEncodedContent(request)).ConfigureAwait(false);
        }

        public async Task<VerifyChannelAccessToken> VerifyShortLonglivedChannelAccessTokenAsync(string channelAccessToken)
        {
            var request = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("access_token", channelAccessToken) 
            };

            return await base.PostAsync<VerifyChannelAccessToken>($"v2/oauth/verify", new FormUrlEncodedContent(request)).ConfigureAwait(false);
        }

        public async Task RevokeShortLongLivedChannelAccessTokenAsync(string channelAccessToken)
        {
            var request = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("access_token", channelAccessToken)
            };

            await base.PostAsync($"v2/oauth/revoke", new FormUrlEncodedContent(request)).ConfigureAwait(false);
        }
    }
}
