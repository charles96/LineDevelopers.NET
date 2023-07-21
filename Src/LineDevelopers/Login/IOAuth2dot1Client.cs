namespace Line.Login
{
    public interface IOAuth2dot1Client
    {
        public Task<AccessTokenInformation> IssueAccessTokenAsync(string authorizationCode, string redirectUri, string clientId, string clientSecret, string? codeVerifier = null);
        public Task<VerifyAccessToken> VerifyAccessTokenValidityAsync(string accessToken);
        public Task<RefreshAccessToken> RefreshAccessTokenAsync(string refreshToken, string clientId, string clientSecret);
        public Task RevokeAccessTokenAsync(string accessToken, string clientId, string clientSecret);
        public Task<VerifyIdToken> VerifyIdTokenAsync(string idToken, string clientId, string? nonce = null, string? userId = null);
        public Task<UserInformation> GetUserInformationAsync(string accessToken);
    }
}
