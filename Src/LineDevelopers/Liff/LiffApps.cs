using System.Text.Json.Serialization;

namespace Line.Liff
{
    public class LiffApps
    {
        [JsonPropertyName("apps")]
        public IList<LiffAppInformation> Apps { get; set; }
    }
}
