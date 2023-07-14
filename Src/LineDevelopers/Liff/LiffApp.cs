using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Liff
{
    public class LiffApp
    {
        public LiffApp() { }

        [SetsRequiredMembers]
        public LiffApp(View view,
                       string? description = null,
                       Features? features = null,
                       string? permanentLinkPattern = null,
                       IList<ScopeType>? scope = null,
                       BotPromptType? botPrompt = null)
        {
            View = view;
            Description = description;
            Features = features;
            PermanentLinkPattern = permanentLinkPattern;
            Scope = scope;
            BotPrompt = botPrompt;
        }

        [JsonPropertyName("view")]
        public required View View { get; set; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        [JsonPropertyName("features")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Features? Features { get; set; }

        [JsonPropertyName("permanentLinkPattern")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PermanentLinkPattern { get; set; }

        [JsonPropertyName("scope")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<ScopeType>? Scope { get; set; }

        [JsonPropertyName("botPrompt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BotPromptType? BotPrompt { get; set; }
    }
}
