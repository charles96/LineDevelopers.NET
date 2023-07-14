using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(Carousel), "carousel")]
    public class Carousel : IContainer
    {
        public Carousel() { }

        [SetsRequiredMembers]
        public Carousel(IList<Bubble> bubbles) 
        { 
            this.Contents = bubbles;
        }

        [JsonPropertyName("contents")]
        public required IList<Bubble> Contents { get; set; }
    }
}
