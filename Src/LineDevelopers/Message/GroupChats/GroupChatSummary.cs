using System.Text.Json.Serialization;

namespace Line.Message
{
    public class GroupChatSummary
    {
        /// <summary>
        /// Group ID
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        [JsonPropertyName("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Group icon URL. Not included in the response if the user doesn't set a group profile icon.
        /// </summary>
        [JsonPropertyName("pictureUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PictureUrl { get; set; }
    }
}
