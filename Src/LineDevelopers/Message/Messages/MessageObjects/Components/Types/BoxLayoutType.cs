using System.Runtime.Serialization;

namespace Line.Message
{
    public enum BoxLayoutType
    {
        [EnumMember(Value = "horizontal")]
        Horizontal,

        [EnumMember(Value = "vertical")]
        Vertical,

        [EnumMember(Value = "baseline")]
        Baseline
    }
}
