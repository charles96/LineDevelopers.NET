using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(OperationSystemDemographicFilterObject), "appType")]
    public class OperationSystemDemographicFilterObject : IDemographicFilterObjects
    {
        public OperationSystemDemographicFilterObject() { }

        [SetsRequiredMembers]
        public OperationSystemDemographicFilterObject(IList<OsType> oneOf)
        {
            OneOf = oneOf;
        }

        [JsonPropertyName("oneOf")]
        public required IList<OsType> OneOf { get; set; }
    }
}
