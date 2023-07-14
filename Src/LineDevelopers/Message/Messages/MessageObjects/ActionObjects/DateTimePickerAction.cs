using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(DateTimePickerAction), "datetimepicker")]
    public class DateTimePickerAction : IAction
    {
        public DateTimePickerAction() { }

        [SetsRequiredMembers]
        public DateTimePickerAction(string data,
                                    ActionModeType mode,
                                    string? label = null,
                                    string? initial = null,
                                    string? max = null,
                                    string? min = null)
        {
            Label = label;
            Data = data;
            Mode = mode;
            Initial = initial;
            Max = max;
            Min = min;
        }

        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        [JsonPropertyName("data")]
        public required string Data { get; set; }

        [JsonPropertyName("mode")]
        public required ActionModeType Mode { get; set; }

        /// <summary>
        /// Initial value of date or time
        /// </summary>
        [JsonPropertyName("initial")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Initial { get; set; }

        /// <summary>
        /// Largest date or time value that can be selected. Must be greater than the min value.
        /// </summary>
        [JsonPropertyName("max")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Max { get; set; }

        /// <summary>
        /// Smallest date or time value that can be selected. Must be less than the max value.
        /// </summary>
        [JsonPropertyName("min")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Min { get; set; }
    }
}
