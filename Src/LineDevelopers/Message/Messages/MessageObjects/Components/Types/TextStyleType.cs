using System.Runtime.Serialization;

namespace Line.Message
{
    public enum TextStyleType
    {
        [EnumMember(Value = "normal")]
        Normal,

        [EnumMember(Value = "italic")]
        Italic
    }
}
