using System.Text.Json.Serialization;

namespace Line
{
    public class CredentialErrorResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("error_description")]
        public string Description { get; set; }
    }
}
