using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(FriendshipDurationDemographicFilterObject), "subscriptionPeriod")]
    public class FriendshipDurationDemographicFilterObject : IDemographicFilterObjects
    {
        public FriendshipDurationDemographicFilterObject() { }

        public FriendshipDurationDemographicFilterObject(DayType? gte = null,
                                                         DayType? lt = null)
        {
            Gte = gte;
            Lt = lt;
        }

        [JsonPropertyName("gte")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DayType? Gte { get; set; }

        [JsonPropertyName("lt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DayType? Lt { get; set; }
    }
}
