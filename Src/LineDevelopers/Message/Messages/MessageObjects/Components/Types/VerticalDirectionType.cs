using System.Runtime.Serialization;

namespace Line.Message
{
    public enum VerticalDirectionType
    {
        [EnumMember(Value = "top")]
        Top,

        [EnumMember(Value = "bottom")]
        Bottom,

        [EnumMember(Value = "center")]
        Center
    }
}
