using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(RichMenuSwitchAction), "richmenuswitch")]
    public class RichMenuSwitchAction : IAction
    {
        public RichMenuSwitchAction() { }

        [SetsRequiredMembers]
        public RichMenuSwitchAction(string richMenuAliasId,
                                    string data,
                                    string? label = null)
        { 
            this.RichMenuAliasId = richMenuAliasId;
            this.Data = data;
            this.Label = label;
        }

        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        [JsonPropertyName("richMenuAliasId")]
        public required string RichMenuAliasId { get; set; }

        [JsonPropertyName("data")]
        public required string Data { get; set; }
    }
}
