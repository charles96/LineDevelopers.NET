using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(UserSource), "user")]
    public class UserSource : ISource
    {
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
    }
}
