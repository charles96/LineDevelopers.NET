using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(RegionDemographicFilterObject), "area")]
    public class RegionDemographicFilterObject : IDemographicFilterObjects
    {
        public RegionDemographicFilterObject() { }

        [SetsRequiredMembers]
        public RegionDemographicFilterObject(IList<RegionType> oneOf)
        {
            OneOf = oneOf;
        }

        [JsonPropertyName("oneOf")]
        public required IList<RegionType> OneOf { get; set; }
    }
}
