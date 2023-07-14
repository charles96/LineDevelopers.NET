using System.Text.Json.Serialization;

namespace Line.Message
{
    public class GroupChatMemberUserIDs
    {
        /// <summary>
        /// List of user IDs of members in the group chat. Only users of LINE for iOS and LINE for Android are included in memberIds. 
        /// For more information, see Consent on getting user profile information.
        /// Max: 100 user IDs
        /// </summary>
        [JsonPropertyName("memberIds")]
        public IList<string> MemberIds { get; set; }

        /// <summary>
        /// A continuation token to get the next array of user IDs of the members in the group chat. 
        /// Returned only when there are remaining user IDs that were not returned in memberIds in the original request.
        /// </summary>
        [JsonPropertyName("next")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Next { get; set; }
    }
}
