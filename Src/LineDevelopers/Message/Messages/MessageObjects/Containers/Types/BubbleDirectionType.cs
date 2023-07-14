using System.Runtime.Serialization;

namespace Line.Message
{
    public enum BubbleDirectionType
    {
        [EnumMember(Value = "ltr")]
        Ltr,

        [EnumMember(Value = "rtl")]
        Rtl
    }
}
