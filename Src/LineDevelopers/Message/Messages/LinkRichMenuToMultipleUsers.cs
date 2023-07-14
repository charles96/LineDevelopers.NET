using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class LinkRichMenuToMultipleUsers
    {
        public LinkRichMenuToMultipleUsers() { }

        [SetsRequiredMembers]
        public LinkRichMenuToMultipleUsers(string richMenuId,
                                           string[] userIds)
        {
            RichMenuId = richMenuId;
            UserIds = userIds;
        }

        [JsonPropertyName("richMenuId")]
        public required string RichMenuId { get; set; }

        [JsonPropertyName("userIds")]
        public required IList<string> UserIds { get; set; }
    }
}
