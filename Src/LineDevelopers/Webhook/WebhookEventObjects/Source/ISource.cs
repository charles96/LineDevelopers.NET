using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(UserSource), "user")]
    [JsonDerivedType(typeof(GroupChatSource), "group")]
    [JsonDerivedType(typeof(MultiPersonChatSource), "room")]
    public interface ISource
    {
        public string UserId { get; set; }
    }
}
