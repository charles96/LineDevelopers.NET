using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(LocationAction), "location")]
    public class LocationAction : IAction
    {
        public LocationAction() { }

        [SetsRequiredMembers]
        public LocationAction(string label) 
        { 
            this.Label = label;
        }

        [JsonPropertyName("label")]
        public required string Label { get; set; }
    }
}
