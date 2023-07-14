using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuSizeObject
    {
        public RichMenuSizeObject() { }

        [SetsRequiredMembers]
        public RichMenuSizeObject(int width,
                                  int height)
        {
            this.Width = width;
            this.Height = height;
        }

        [JsonPropertyName("width")]
        public required int Width { get; set; }

        [JsonPropertyName("height")]
        public required int Height { get; set; }
    }
}
