using System.Net.Http.Headers;

namespace Line.Login
{
    public interface IOAuth2dot1Client
    {
        public Task<AccessTokenInformation> IssueAccessTokenAsync(string authorizationCode, string redirectUri, string clientId, string clientSecret, string? codeVerifier = null, Action<HttpResponseHeaders>? getResponseHeaders = null);
        public Task<VerifyAccessToken> VerifyAccessTokenValidityAsync(string accessToken, Action<HttpResponseHeaders>? getResponseHeaders = null);
        public Task<RefreshAccessToken> RefreshAccessTokenAsync(string refreshToken, string clientId, string clientSecret, Action<HttpResponseHeaders>? getResponseHeaders = null);
        public Task RevokeAccessTokenAsync(string accessToken, string clientId, string clientSecret, Action<HttpResponseHeaders>? getResponseHeaders = null);
        public Task<VerifyIdToken> VerifyIdTokenAsync(string idToken, string clientId, string? nonce = null, string? userId = null, Action<HttpResponseHeaders>? getResponseHeaders = null);
        public Task<UserInformation> GetUserInformationAsync(string accessToken, Action<HttpResponseHeaders>? getResponseHeaders = null);
    }
}
