using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuBatchControl
    {
        [JsonPropertyName("operations")]
        public IList<RichMenuOperationObject> Operations { get; set; }

        [JsonPropertyName("resumeRequestKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ResumeRequestKey { get; set; }
    }
}
