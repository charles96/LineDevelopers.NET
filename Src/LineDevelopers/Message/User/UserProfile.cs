using System.Text.Json.Serialization;

namespace Line.Message
{
    /// <summary>
    /// You can get the profile information of users who meet one of two conditions:
    /// Users who have added your LINE Official Account as a friend
    /// Users who haven't added your LINE Official Account as a friend but have sent a message to your LINE Official Account (except users who have blocked your LINE Official Account)
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// User's display name
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// User's language, as a BCP 47 (opens new window)language tag. Not included in the response if the user hasn't yet consented to the LINE Privacy Policy.
        /// e.g.en for English.
        /// </summary>
        [JsonPropertyName("language")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Language { get; set; }

        /// <summary>
        /// Profile image URL. "https" image URL. Not included in the response if the user doesn't have a profile image.
        /// </summary>
        [JsonPropertyName("pictureUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PictureUrl { get; set; }

        /// <summary>
        /// User's status message. Not included in the response if the user doesn't have a status message.
        /// </summary>
        [JsonPropertyName("statusMessage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StatusMessage { get; set; }
    }
}
