using System.Runtime.Serialization;

namespace Line.Message
{
    public enum JustifyContentType
    {
        [EnumMember(Value = "flex-start")]
        FlexStart,

        [EnumMember(Value = "center")]
        Center,

        [EnumMember(Value = "flex-end")]
        FlexEnd,

        [EnumMember(Value = "space-between")]
        SpaceBetween,

        [EnumMember(Value = "space-around")]
        SpaceAround,

        [EnumMember(Value = "space-evenly")]
        SpaceEvenly
    }
}
