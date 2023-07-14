using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(UriAction), "uri")]
    public class UriAction : IAction
    {
        public UriAction() { }

        [SetsRequiredMembers]
        public UriAction(string uri,
                         string? label = null,
                         AlternativeUrl? altUri = null) 
        {
            this.Uri = uri;
            this.Label = label;
            this.AltUri = altUri;
        }

        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        [JsonPropertyName("uri")]
        public required string Uri { get; set; }

        [JsonPropertyName("altUri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AlternativeUrl? AltUri { get; set; }
    }
}
