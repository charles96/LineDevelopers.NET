using System.Runtime.Serialization;

namespace Line.Message
{
    public enum BubbleSizeType
    {
        [EnumMember(Value = "nano")]
        Nano,

        [EnumMember(Value = "micro")]
        Micro,

        [EnumMember(Value = "kilo")]
        Kilo,

        [EnumMember(Value = "mega")]
        Mega,

        [EnumMember(Value = "giga")]
        Giga
    }
}
