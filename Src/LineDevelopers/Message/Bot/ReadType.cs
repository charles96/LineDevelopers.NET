using System.Runtime.Serialization;

namespace Line.Message
{
    public enum ReadType
    {
        [EnumMember(Value = "auto")]
        Auto,

        [EnumMember(Value = "manual")]
        Manual
    }
}
