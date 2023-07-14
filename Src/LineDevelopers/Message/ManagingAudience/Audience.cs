using System.Text.Json.Serialization;

namespace Line.Message
{
    public class Audience
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }  
    }
}
