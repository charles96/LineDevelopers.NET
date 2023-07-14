using System.Text.Json.Serialization;

namespace Line.Message
{
    public class AlternativeUrl
    {
        public AlternativeUrl() { }

        public AlternativeUrl(string? desktop = null)
        {
            Desktop = desktop;
        }

        [JsonPropertyName("desktop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Desktop { get; set; }
    }
}
