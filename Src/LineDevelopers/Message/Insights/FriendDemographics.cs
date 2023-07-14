using System.Text.Json.Serialization;

namespace Line.Message
{
    public class FriendDemographics
    {
        /// <summary>
        /// true if friend demographic information is available.
        /// </summary>
        [JsonPropertyName("available")]
        public bool Available { get; set; }

        /// <summary>
        /// Percentage per gender
        /// </summary>
        [JsonPropertyName("genders")]
        public IList<GenderItem> Genders { get; set; }

        /// <summary>
        /// Percentage per age group
        /// </summary>
        [JsonPropertyName("ages")]
        public IList<AgeItem> Ages { get; set; }

        /// <summary>
        /// Percentage per area
        /// </summary>
        [JsonPropertyName("areas")]
        public IList<AreaItem> Areas { get; set; }

        /// <summary>
        /// Percentage by OS
        /// </summary>
        [JsonPropertyName("appTypes")]
        public IList<AppTypeItem> AppTypes { get; set; }
    }
}
