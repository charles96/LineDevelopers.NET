using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(AudienceObject), "audience")]
    [JsonDerivedType(typeof(RedeliveryObject), "redelivery")]
    [JsonDerivedType(typeof(LogicalOperatorObject), "operator")]
    public interface IRecipientObject
    {
    }
}
