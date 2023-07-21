using System.Text.Json.Serialization;

namespace Line.Login
{
    public class VerifyAccessToken
    {
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }
    }
}
