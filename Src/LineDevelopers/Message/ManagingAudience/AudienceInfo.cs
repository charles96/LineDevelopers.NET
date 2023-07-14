using System.Text.Json.Serialization;

namespace Line.Message
{
    public class AudienceInfo
    {
        [JsonPropertyName("audienceGroupId")]
        public long AudienceGroupId { get; set; }

        [JsonPropertyName("createRoute")]
        public string CreateRoute { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("created")]
        public long Created { get; set; }

        [JsonPropertyName("permission")]
        public PermissionType Permission { get; set; }

        [JsonPropertyName("expireTimestamp")]
        public long ExpireTimestamp { get; set; }

        [JsonPropertyName("isIfaAudience")]
        public bool IsIfaAudience { get; set; }
    }
}
