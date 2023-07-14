using System.Runtime.Serialization;

namespace Line.Message
{
    public enum PositionType
    {
        [EnumMember(Value = "relative")]
        Relative,

        [EnumMember(Value = "absolute")]
        Absolute
    }
}
