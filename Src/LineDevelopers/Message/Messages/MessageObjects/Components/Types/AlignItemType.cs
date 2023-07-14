using System.Runtime.Serialization;

namespace Line.Message
{
    public enum AlignItemType
    {
        [EnumMember(Value = "flex-start")]
        FlexStart,

        [EnumMember(Value = "center")]
        Center,

        [EnumMember(Value = "flex-end")]
        FlexEnd
    }
}
