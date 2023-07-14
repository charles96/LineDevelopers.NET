using System.Runtime.Serialization;

namespace Line.Message
{
    public enum DayType
    {
        [EnumMember(Value = "day_7")]
        Day7,

        [EnumMember(Value = "day_30")]
        Day30,

        [EnumMember(Value = "day_90")]
        Day90,

        [EnumMember(Value = "day_180")]
        Day180,

        [EnumMember(Value = "day_365")]
        Day365
    }
}
