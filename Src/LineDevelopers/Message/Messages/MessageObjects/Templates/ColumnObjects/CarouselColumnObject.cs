using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class CarouselColumnObject
    {
        public CarouselColumnObject() { }
                
        [SetsRequiredMembers]
        public CarouselColumnObject(string text,
                                    IList<IAction> actions,
                                    IAction? defaultAction = null,
                                    string? title = null,
                                    string? thumbnailImageUrl = null,
                                    string? imageBackgroundColor = null)
        {
            ThumbnailImageUrl = thumbnailImageUrl;
            ImageBackgroundColor = imageBackgroundColor;
            Title = title;
            Text = text;
            DefaultAction = defaultAction;
            Actions = actions;
        }

        [JsonPropertyName("thumbnailImageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ThumbnailImageUrl { get; set; }

        [JsonPropertyName("imageBackgroundColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageBackgroundColor { get; set; }

        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }

        [JsonPropertyName("text")]
        public required string Text { get; set; }

        [JsonPropertyName("defaultAction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IAction? DefaultAction { get; set; }

        [JsonPropertyName("actions")]
        public required IList<IAction> Actions { get; set; }
    }
}
