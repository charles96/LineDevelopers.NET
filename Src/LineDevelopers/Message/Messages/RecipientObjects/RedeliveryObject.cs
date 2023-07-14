using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(RedeliveryObject), "redelivery")]
    public class RedeliveryObject : IRecipientObject
    {
        public RedeliveryObject() { }

        [SetsRequiredMembers]
        public RedeliveryObject(string requestId)
        {
            RequestId = requestId;
        }

        [JsonPropertyName("requestId")]
        public required string RequestId { get; set; }
    }
}
