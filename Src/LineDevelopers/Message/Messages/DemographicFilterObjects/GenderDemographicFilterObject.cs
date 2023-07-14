using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(GenderDemographicFilterObject), "gender")]
    public class GenderDemographicFilterObject : IDemographicFilterObjects
    {
        public GenderDemographicFilterObject() { }

        [SetsRequiredMembers]
        public GenderDemographicFilterObject(IList<GenderType> oneOf)
        {
            OneOf = oneOf;
        }

        [JsonPropertyName("oneOf")]
        public required IList<GenderType> OneOf { get; set; }
    }
}
