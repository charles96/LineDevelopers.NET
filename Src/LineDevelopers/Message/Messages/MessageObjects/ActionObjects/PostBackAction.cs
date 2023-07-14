using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(PostBackAction), "postback")]
    public class PostBackAction : IAction
    {
        public PostBackAction() { }

        [SetsRequiredMembers]
        public PostBackAction(string data,
                              string? label = null,
                              string? displayText = null,
                              string? text = null,
                              InputOptions? inputOption = null,
                              string? fillInText = null)
        {
            Data = data;
            Label = label;
            DisplayText = displayText;
            Text = text;
            InputOption = inputOption;
            FillInText = fillInText;
        }

        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        [JsonPropertyName("data")]
        public required string Data { get; set; }

        [JsonPropertyName("displayText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DisplayText { get; set; }

        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Text { get; set; }

        [JsonPropertyName("inputOption")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public InputOptions? InputOption { get; set; }

        [JsonPropertyName("fillInText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FillInText { get; set; }
    }
}
