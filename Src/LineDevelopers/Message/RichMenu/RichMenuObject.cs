using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuObject
    {
        public RichMenuObject() { }

        [SetsRequiredMembers]
        public RichMenuObject(RichMenuSizeObject richMenuSizeObject,
                              bool selected,
                              string name,
                              string chartBarText,
                              IList<RichMenuAreaObject> richMenuAreaObjects)
        {
            this.Size = richMenuSizeObject;
            this.Selected = selected;
            this.Name = name;
            this.ChatBarText = chartBarText;
            this.Areas = richMenuAreaObjects;
        }

        [JsonPropertyName("size")]
        public required RichMenuSizeObject Size { get; set; }

        [JsonPropertyName("selected")]
        public required bool Selected { get; set; }
        
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("chatBarText")]
        public required string ChatBarText { get; set; }

        [JsonPropertyName("areas")]
        public required IList<RichMenuAreaObject> Areas { get; set; }
    }
}
