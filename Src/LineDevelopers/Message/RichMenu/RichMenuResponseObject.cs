using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuResponseObject : RichMenuObject
    {
        [JsonPropertyName("richMenuId")]
        public string RichMenuId { get; set; }
    }
}
