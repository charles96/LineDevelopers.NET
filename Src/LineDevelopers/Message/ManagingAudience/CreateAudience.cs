using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    public class CreateAudience
    {
        public CreateAudience() { }

        [SetsRequiredMembers]
        public CreateAudience(string description,
                              bool? isIfaAudience,
                              string? uploadDescription,
                              IList<Audience>? audiences)
        {
            Description = description;
            IsIfaAudience = isIfaAudience;
            UploadDescription = uploadDescription;
            Audiences = audiences;
        }

        [JsonPropertyName("description")]
        public required string Description {  get; set; }

        [JsonPropertyName("isIfaAudience")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsIfaAudience { get; set; }

        [JsonPropertyName("uploadDescription")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UploadDescription { get; set; }

        [JsonPropertyName("audiences")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Audience>? Audiences { get; set; }
    }
}
