using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Liff
{
    public class View
    {
        public View() { }

        [SetsRequiredMembers]
        public View(ViewType type,
                    string url,
                    bool? moduleMode = null)
        {
            Type = type;
            Url = url;
            ModuleMode = moduleMode;
        }

        [JsonPropertyName("type")]
        public required ViewType Type { get; set; }

        [JsonPropertyName("url")]
        public required string Url { get; set; }

        [JsonPropertyName("moduleMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ModuleMode { get; set; }
    }
}
