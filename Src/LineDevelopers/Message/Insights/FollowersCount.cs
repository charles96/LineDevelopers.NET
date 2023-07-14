using System.Text.Json.Serialization;

namespace Line.Message
{
    public class FollowersCount
    {
        /// <summary>
        /// Calculation status.
        /// Ready: Calculation has finished. The numbers are up-to-date.
        /// UnReady: We haven't finished calculating followers for the specified date. Try again later. Calculation usually takes about a day.
        /// OutOfService: The specified date is earlier than the date on which we first started calculating followers (November 1, 2016).
        /// </summary>
        [JsonPropertyName("status")]
        public CalculationStatus Status { get; set; }

        /// <summary>
        /// The number of times, as of the specified date, that a user added this LINE Official Account as a friend for the first time. The number doesn't decrease even if a user later blocks the account or when they delete their LINE account.
        /// </summary>
        [JsonPropertyName("followers")]
        public int Followers { get; set; }

        /// <summary>
        /// The number of users, as of the specified date, that the LINE Official Account can reach through targeted messages based on gender, age, and/or region. This number only includes users who are active on LINE or LINE services and whose demographics have a high level of certainty.
        /// </summary>
        [JsonPropertyName("targetedReaches")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? targetedReaches { get; set; }

        /// <summary>
        /// The number of users blocking the account as of the specified date. The number decreases when a user unblocks the account.
        /// </summary>
        [JsonPropertyName("blocks")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Blocks { get; set; }
    }
}
