using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class ImageMapArea
    {
        public ImageMapArea() { }

        [SetsRequiredMembers]
        public ImageMapArea(int x,
                            int y,
                            int width,
                            int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Horizontal position of the video area relative to the left edge of the imagemap area. Value must be 0 or higher.
        /// </summary>
        [JsonPropertyName("x")]
        public required int X { get; set; }

        /// <summary>
        /// Vertical position of the video area relative to the top of the imagemap area. Value must be 0 or higher.
        /// </summary>
        [JsonPropertyName("y")]
        public required int Y { get; set; }

        /// <summary>
        /// Width of the video area
        /// </summary>
        [JsonPropertyName("width")]
        public required int Width { get; set; }

        /// <summary>
        /// Height of the video area
        /// </summary>
        [JsonPropertyName("height")]
        public required int Height { get; set; }
    }
}
