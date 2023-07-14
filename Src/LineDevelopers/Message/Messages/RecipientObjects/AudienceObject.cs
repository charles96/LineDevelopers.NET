using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(AudienceObject), "audience")]
    public class AudienceObject : IRecipientObject
    {
        public AudienceObject() { }

        [SetsRequiredMembers]
        public AudienceObject(long audienceGroupId)
        {
            AudienceGroupId = audienceGroupId;
        }

        [JsonPropertyName("audienceGroupId")]
        public required long AudienceGroupId { get; set; }
    }
}
