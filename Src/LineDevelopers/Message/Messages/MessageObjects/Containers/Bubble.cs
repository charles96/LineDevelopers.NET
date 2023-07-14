using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(Bubble), "bubble")]
    public class Bubble : IContainer
    {
        public Bubble() { }

        public Bubble(BubbleSizeType? size = null,
                      BubbleDirectionType? direction = null,
                      BoxComponent? header = null,
                      IComponent? hero = null,
                      BoxComponent? body = null,
                      BoxComponent? footer = null,
                      BubbleStyle? styles = null,
                      IAction? action = null)
        {
            Size = size;
            Direction = direction;
            Header = header;
            Hero = hero;
            Body = body;
            Footer = footer;
            Styles = styles;
            Action = action;
        }

        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BubbleSizeType? Size { get; set; }

        [JsonPropertyName("direction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BubbleDirectionType? Direction { get; set; }

        /// <summary>
        /// Header block. Specify a Box.
        /// </summary>
        [JsonPropertyName("header")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BoxComponent? Header { get; set; }

        /// <summary>
        /// Hero block. Specify a box, an image or a video.
        /// </summary>
        [JsonPropertyName("hero")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IComponent? Hero { get; set; }

        /// <summary>
        /// Body block. Specify a Box.
        /// </summary>
        [JsonPropertyName("body")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BoxComponent? Body { get; set; }

        /// <summary>
        /// Footer block. Specify a Box.
        /// </summary>
        [JsonPropertyName("footer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BoxComponent? Footer { get; set; }

        /// <summary>
        /// Style of each block
        /// </summary>
        [JsonPropertyName("styles")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BubbleStyle? Styles { get; set; }

        /// <summary>
        /// Action performed when this image is tapped.
        /// </summary>
        [JsonPropertyName("action")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IAction? Action { get; set; }
    }
}
