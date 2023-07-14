using System.Runtime.Serialization;

namespace Line.Message
{
    public enum ActionModeType
    {
        [EnumMember(Value = "date")]
        Date,

        [EnumMember(Value = "time")]
        Time,

        [EnumMember(Value = "datetime")]
        Datetime
    }
}
