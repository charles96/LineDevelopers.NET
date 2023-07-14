using System.Text.Json.Serialization;

namespace Line.Message.Bot
{
    /// <summary>
    /// Gets a bot's basic information.
    /// </summary>
    public class BotInfo
    {
        /// <summary>
        /// Bot's user ID
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Bot's basic ID
        /// </summary>
        [JsonPropertyName("basicId")]
        public string BasicId { get; set; }

        /// <summary>
        /// Bot's premium ID. Not included in the response if the premium ID isn't set.
        /// </summary>
        [JsonPropertyName("premiumId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PremiumId { get; set; }

        /// <summary>
        /// Bot's display name
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Profile image URL. "https" image URL. Not included in the response if the bot doesn't have a profile image.
        /// </summary>
        [JsonPropertyName("pictureUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PictureUrl { get; set; }

        /// <summary>
        /// Chat settings set in the LINE Official Account Manager (opens new window). One of:
        /// chat: Chat is set to "On".
        /// bot: Chat is set to "Off".
        /// </summary>
        [JsonPropertyName("chatMode")]
        public string ChatMode { get; set; }

        /// <summary>
        /// Automatic read setting for messages. If the chat is set to "Off", auto is returned. If the chat is set to "On", manual is returned.
        /// auto: Auto read setting is enabled.
        /// manual: Auto read setting is disabled.
        /// </summary>
        [JsonPropertyName("markAsReadMode")]
        public string MarkAsReadMode { get; set; }
    }
}
