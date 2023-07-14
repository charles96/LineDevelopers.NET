using System.Runtime.Serialization;

namespace Line.Message
{
    public enum ButtonStyleType
    {
        [EnumMember(Value = "primary")]
        Primary,

        [EnumMember(Value = "secondary")]
        Secondary,

        [EnumMember(Value = "link")]
        Link
    }
}
