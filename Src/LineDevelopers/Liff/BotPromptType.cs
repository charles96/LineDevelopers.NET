using System.Runtime.Serialization;

namespace Line.Liff
{
    public enum BotPromptType
    {
        [EnumMember(Value = "normal")]
        Normal,

        [EnumMember(Value = "aggressive")]
        Aggressive,

        [EnumMember(Value = "none")]
        None
    }
}
