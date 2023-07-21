using System.Text.Json.Serialization;

namespace Line.Login
{
    public class VerifyIdToken : UserInformation
    {
        [JsonPropertyName("iss")]
        public string Iss { get; set; }

        [JsonPropertyName("aud")]
        public string Aud { get; set; }

        [JsonPropertyName("exp")]
        public long Exp { get; set; }

        [JsonPropertyName("iat")]
        public long Iat { get; set; }

        [JsonPropertyName("auth_time")]
        public long AuthTime { get; set; }

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }

        [JsonPropertyName("amr")]
        public IList<AmrType> Amr { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
