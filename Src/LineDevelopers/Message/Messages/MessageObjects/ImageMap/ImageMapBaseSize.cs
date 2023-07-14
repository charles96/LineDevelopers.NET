using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class ImageMapBaseSize
    {
        public ImageMapBaseSize() { }

        [SetsRequiredMembers]
        public ImageMapBaseSize(int width,
                                int height) 
        { 
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Width of base image in pixels. Set to 1040.
        /// </summary>
        [JsonPropertyName("width")]
        public required int Width { get; set; }

        /// <summary>
        /// Height of base image. Set to the height that corresponds to a width of 1040 pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public required int Height { get; set; }
    }
}
