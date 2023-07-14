using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuBoundsObject
    {
        public RichMenuBoundsObject() { }

        [SetsRequiredMembers]
        public RichMenuBoundsObject(int x,
                                    int y,
                                    int width,
                                    int height) 
        { 
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        [JsonPropertyName("x")]
        public required int X { get; set; }

        [JsonPropertyName("y")]
        public required int Y { get; set; }

        [JsonPropertyName("width")]
        public required int Width { get; set; }

        [JsonPropertyName("height")]
        public required int Height { get; set; }
    }
}
