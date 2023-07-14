using System.Text.Json.Serialization;

namespace Line.Liff
{
    public class Features
    {
        [JsonPropertyName("ble")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Ble { get; set; }

        [JsonPropertyName("qrCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? QrCode { get; set; }
    }
}
