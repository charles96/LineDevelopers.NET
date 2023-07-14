using System.Text.Json.Serialization;

namespace Line
{
    public class ErrorResponse
    {
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }

        [JsonPropertyName("details")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Detail>? Details { get; set; }
    }
}