using System.Runtime.Serialization;

namespace Line.Message
{
    public enum HorizontalDirectionType
    {
        [EnumMember(Value = "start")]
        Start,

        [EnumMember(Value = "end")]
        End,

        [EnumMember(Value = "center")]
        Center
    }
}
