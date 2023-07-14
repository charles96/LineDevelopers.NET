using System.Text.Json.Serialization;

namespace Line.Message
{
    public class ImageMapVideoArea
    {
        public ImageMapVideoArea() { }

        public ImageMapVideoArea(int? x = null,
                                 int? y = null,
                                 int? width = null,
                                 int? height = null)
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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? X { get; set; }

        /// <summary>
        /// Vertical position of the video area relative to the top of the imagemap area. Value must be 0 or higher.
        /// </summary>
        [JsonPropertyName("y")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Y { get; set; }

        /// <summary>
        /// Width of the video area
        /// </summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Width { get; set; }

        /// <summary>
        /// Height of the video area
        /// </summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Height { get; set; }
    }
}
