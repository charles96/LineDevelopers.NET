using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuAreaObject
    {
        public RichMenuAreaObject() { }

        [SetsRequiredMembers]
        public RichMenuAreaObject(RichMenuBoundsObject bounds,
                                  IAction action)
        {
            Bounds = bounds;
            Action = action;
        }

        [JsonPropertyName("bounds")]
        public required RichMenuBoundsObject Bounds { get; set; }

        [JsonPropertyName("action")]
        public required IAction Action { get; set; }
    }
}
