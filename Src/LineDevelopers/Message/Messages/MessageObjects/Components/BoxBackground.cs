using System.Text.Json.Serialization;

namespace Line.Message
{
    public class BoxBackground
    {
        public BoxBackground() { }

        public BoxBackground(string? angle = null,
                             string? startColor = null,
                             string? endColor = null,
                             string? centerColor = null,
                             string? centerPosition = null)
        {
            Angle = angle;
            StartColor = startColor;
            EndColor = endColor;
            CenterColor = centerColor;
            CenterPosition = centerPosition;
        }

        /// <summary>
        /// The type of background used. Specify these values:
        /// linearGradient: Linear gradient.For more information, see Linear gradient backgrounds in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get => "linearGradient"; }

        /// <summary>
        /// The angle at which a linear gradient moves. 
        /// Specify the angle using an integer value like 90deg (90 degrees) or a decimal number like 23.5deg (23.5 degrees) in the half-open interval [0, 360). The direction of the linear gradient rotates clockwise as the angle increases. Given a value of 0deg, the gradient starts at the bottom and ends at the top; given a value of 45deg, the gradient starts at the bottom-left corner and ends at the top-right corner; given a value of 90deg, the gradient starts at the left and ends at the right; and given a value of 180deg, the gradient starts at the top and ends at the bottom. 
        /// For more information, see Direction (angle) of linear gradient backgrounds in the Messaging API documentation.
        /// This is required when background.type is linearGradient.
        /// </summary>
        [JsonPropertyName("angle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Angle { get; set; }

        /// <summary>
        /// The color at the gradient's starting point. Use a hexadecimal color code in the #RRGGBB or #RRGGBBAA format.
        /// This is required when background.type is linearGradient.
        /// </summary>
        [JsonPropertyName("startColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StartColor { get; set; }

        /// <summary>
        /// The color at the gradient's ending point. Use a hexadecimal color code in the #RRGGBB or #RRGGBBAA format.
        /// This is required when background.type is linearGradient.
        /// </summary>
        [JsonPropertyName("endColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EndColor { get; set; }

        /// <summary>
        /// The color in the middle of the gradient. Use a hexadecimal color code in the #RRGGBB or #RRGGBBAA format. 
        /// Specify a value for the background.centerColor property to create a gradient that has three colors. 
        /// For more information, see Intermediate color stops for linear gradients in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("centerColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CenterColor { get; set; }

        /// <summary>
        /// The position of the intermediate color stop. Specify an integer or decimal value between 0% (the starting point) and 100% (the ending point). This is 50% by default. 
        /// For more information, see Intermediate color stops for linear gradients in the Messaging API documentation.
        /// </summary>
        [JsonPropertyName("centerPosition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CenterPosition { get; set; }
    }
}
