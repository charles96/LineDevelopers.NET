using System.Text.Json.Serialization;

namespace Line.Message
{
    [Obsolete("FillerComponent is deprecated")]
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(FillerComponent), "filler")]
    public class FillerComponent : IComponent
    {
        public FillerComponent() { }

        public FillerComponent(int? flex = null) 
        {
            this.Flex = flex;
        }

        [JsonPropertyName("flex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Flex { get; set; }
    }
}
