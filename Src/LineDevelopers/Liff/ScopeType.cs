using System.Runtime.Serialization;

namespace Line.Liff
{
    public enum ScopeType
    {
        [EnumMember(Value = "openid")]
        OpenId,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "profile")]
        Profile,

        [EnumMember(Value = "chat_message.write")]
        ChatMessageWrite
    }
}