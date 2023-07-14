using System.Text.Json.Serialization;

namespace Line.Liff
{
    public class LiffAppInformation : LiffApp
    {
        [JsonPropertyName("liffId")]
        public string LiffId { get; set; }
    }
}
