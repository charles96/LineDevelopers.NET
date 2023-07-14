using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuAlias
    {
        public RichMenuAlias() { }

        [SetsRequiredMembers]
        public RichMenuAlias(string richMenuAliasId,
                             string richMenuId)
        {
            RichMenuAliasId = richMenuAliasId;
            RichMenuId = richMenuId;
        }

        [JsonPropertyName("richMenuAliasId")]
        public required string RichMenuAliasId { get; set; }

        [JsonPropertyName("richMenuId")]
        public required string RichMenuId { get; set; }
    }
}
