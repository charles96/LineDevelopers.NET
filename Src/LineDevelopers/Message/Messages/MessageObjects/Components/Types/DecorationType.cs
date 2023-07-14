using System.Runtime.Serialization;

namespace Line.Message
{
    public enum DecorationType
    {
        [EnumMember(Value = "none")]
        None,

        [EnumMember(Value = "underline")]
        Underline,

        [EnumMember(Value = "line-through")]
        LineThrough,
    }
}
