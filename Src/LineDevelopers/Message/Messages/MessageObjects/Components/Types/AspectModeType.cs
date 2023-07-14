using System.Runtime.Serialization;

namespace Line.Message
{
    public enum AspectModeType
    {
        [EnumMember(Value = "cover")]
        Cover,

        [EnumMember(Value = "fit")]
        Fit
    }
}
