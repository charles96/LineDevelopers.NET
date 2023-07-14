using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(AgeDemographicFilterObject), "age")]
    public class AgeDemographicFilterObject : IDemographicFilterObjects
    {
        public AgeDemographicFilterObject() { }

        public AgeDemographicFilterObject(AgeType? gte = null,
                                          AgeType? lt = null)
        {
            Gte = gte;
            Lt = lt;
        }

        [JsonPropertyName("gte")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AgeType? Gte { get; set; }

        [JsonPropertyName("lt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AgeType? Lt { get; set; }
    }
}
