using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuOperationObject
    {
        public RichMenuOperationObject() { }

        [SetsRequiredMembers]
        public RichMenuOperationObject(RichMenuOperationType type,
                                       string? from,
                                       string? to)
        {
            Type = type;
            From = from;
            To = to;
        }

        [JsonPropertyName("type")]
        public required RichMenuOperationType Type { get; set; }

        [JsonPropertyName("from")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? From { get; set; }


        [JsonPropertyName("to")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? To { get; set; }
    }
}
