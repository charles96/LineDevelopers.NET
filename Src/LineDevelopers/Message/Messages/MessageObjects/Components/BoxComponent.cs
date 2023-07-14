using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    /// <summary>
    /// This is a component that defines the layout of child components. You can also include a box in a box.
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(BoxComponent), "box")]
    public class BoxComponent : IComponent
    {
        public BoxComponent() { }

        [SetsRequiredMembers]
        public BoxComponent(BoxLayoutType layout,
                            IList<IComponent> contents,
                            string? backgroundColor = null,
                            string? borderColor = null,
                            string? borderWidth = null,
                            string? cornerRadius = null,
                            string? width = null,
                            string? maxWidth = null,
                            string? height = null,
                            string? maxHeight = null,
                            int? flex = null,
                            string? spacing = null,
                            string? margin = null,
                            string? paddingAll = null,
                            string? paddingTop = null,
                            string? paddingBottom = null,
                            string? paddingStart = null,
                            string? paddingEnd = null,
                            PositionType? position = null,
                            string? offsetTop = null,
                            string? offsetBottom = null,
                            string? offsetStart = null,
                            string? offsetEnd = null,
                            IAction? action = null,
                            JustifyContentType? justifyContent = null,
                            AlignItemType? alignItems = null,
                            BoxBackground? background = null)
        {
            Layout = layout;
            Contents = contents;
            BackgroundColor = backgroundColor;
            BorderColor = borderColor;
            BorderWidth = borderWidth;
            CornerRadius = cornerRadius;
            Width = width;
            MaxWidth = maxWidth;
            Height = height;
            MaxHeight = maxHeight;
            Flex = flex;
            Spacing = spacing;
            Margin = margin;
            PaddingAll = paddingAll;
            PaddingTop = paddingTop;
            PaddingBottom = paddingBottom;
            PaddingStart = paddingStart;
            PaddingEnd = paddingEnd;
            Position = position;
            OffsetTop = offsetTop;
            OffsetBottom = offsetBottom;
            OffsetStart = offsetStart;
            OffsetEnd = offsetEnd;
            Action = action;
            JustifyContent = justifyContent;
            AlignItems = alignItems;
            Background = background;
        }

        /// <summary>
        /// The layout style of components in this box. 
        /// For more information, see Direction of placing components in the API documentation.
        /// </summary>
        [JsonPropertyName("layout")]
        public required BoxLayoutType Layout { get; set; }

        /// <summary>
        /// Components in this box. Here are the types of components available:
        /// When the layout property is horizontal or vertical: box, button, image, text, separator, and filler
        /// When the layout property is baseline: icon, text, and filler
        /// Components are rendered in the same order specified in the array.You may also specify an empty array.
        /// </summary>
        [JsonPropertyName("contents")]
        public required IList<IComponent> Contents { get; set; }

        /// <summary>
        /// Background color of the block. 
        /// In addition to the RGB color, an alpha channel (transparency) can also be set. 
        /// Use a hexadecimal color code. (e.g. #RRGGBBAA) The default value is #00000000.
        /// </summary>
        [JsonPropertyName("backgroundColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// Color of box border. Use a hexadecimal color code.
        /// </summary>
        [JsonPropertyName("borderColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BorderColor { get; set; }

        /// <summary>
        /// Width of box border. You can specify a value in pixels or any one of none, light, normal, medium, semi-bold, or bold. 
        /// A value of none means that borders are not rendered; the other values are listed in order of increasing width.
        /// </summary>
        [JsonPropertyName("borderWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BorderWidth { get; set; }

        /// <summary>
        /// Radius at the time of rounding the corners of the border. You can specify a value in pixels or any one of none, xs, sm, md, lg, xl, or xxl. 
        /// none doesn't round the corner while the others increase in radius in the order of listing. The default value is none.
        /// </summary>
        [JsonPropertyName("cornerRadius")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CornerRadius { get; set; }

        /// <summary>
        /// Box width. The value should be given in pixels or as a percentage of the width of the parent element. 
        /// For more information, see Box width in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Width { get; set; }

        /// <summary>
        /// Max width of the box. The value should be given in pixels or as a percentage of the width of the parent element. 
        /// For more information, see Max width of a box in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("maxWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MaxWidth { get; set; }

        /// <summary>
        /// Box height. The value should be given in pixels or as a percentage of the height of the parent element. 
        /// For more information, see Box height in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Height { get; set; }

        /// <summary>
        /// Max height of the box. The value should be given in pixels or as a percentage of the height of the parent element. 
        /// For more information, see Max height of a box in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("maxHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MaxHeight { get; set; }

        /// <summary>
        /// The ratio of the width or height of this component within the parent box. 
        /// For more information, see Width and height of components in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("flex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Flex { get; set; }

        /// <summary>
        /// Minimum space between components in this box. The default value is none. 
        /// For more information, see spacing property of the box in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("spacing")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Spacing { get; set; }

        /// <summary>
        /// The minimum amount of space to include before this component in its parent container. 
        /// For more information, see margin property of the component in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("margin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Margin { get; set; }

        [JsonPropertyName("paddingAll")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PaddingAll { get; set; }

        [JsonPropertyName("paddingTop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PaddingTop { get; set; }

        [JsonPropertyName("paddingBottom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PaddingBottom { get; set; }

        [JsonPropertyName("paddingStart")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PaddingStart { get; set; }

        [JsonPropertyName("paddingEnd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PaddingEnd { get; set; }

        /// <summary>
        /// Reference position for placing this box. Specify one of the following values:
        /// relative: Use the previous box as reference.
        /// absolute: Use the top left of parent element as reference.
        /// The default value is relative.For more information, see Offset in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("position")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PositionType? Position { get; set; }

        [JsonPropertyName("offsetTop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OffsetTop { get; set; }

        /// <summary>
        /// Offset. For more information, see Offset in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("offsetBottom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OffsetBottom { get; set; }

        /// <summary>
        /// Offset. For more information, see Offset in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("offsetStart")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OffsetStart { get; set; }

        /// <summary>
        /// Offset. For more information, see Offset in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("offsetEnd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OffsetEnd { get; set; }

        /// <summary>
        /// Action performed when this image is tapped. Specify an action object.
        /// </summary>
        [JsonPropertyName("action")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IAction? Action { get; set; }

        /// <summary>
        /// How child elements are aligned along the main axis of the parent element. 
        /// If the parent element is a horizontal box, this only takes effect when its child elements have their flex property set equal to 0. 
        /// For more information, see Arranging a box's child elements and free space in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("justifyContent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JustifyContentType? JustifyContent { get; set; }

        /// <summary>
        /// How child elements are aligned along the cross axis of the parent element. 
        /// For more information, see Arranging a box's child elements and free space in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("alignItems")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AlignItemType? AlignItems { get; set; }

        [JsonPropertyName("background")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BoxBackground? Background { get; set; }
    }
}
