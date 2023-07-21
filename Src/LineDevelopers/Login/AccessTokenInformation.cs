using System.Text.Json.Serialization;

namespace Line.Login
{
    public class AccessTokenInformation : RefreshAccessToken
    {
        [JsonPropertyName("id_token")]
        public string IdToken { get; set; }
    }
}
