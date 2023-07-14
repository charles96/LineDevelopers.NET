using System.Runtime.Serialization;

namespace Line.Message
{
    public enum AgeType
    {
        [EnumMember(Value = "age_15")]
        Age15,

        [EnumMember(Value = "age_20")]
        Age20,

        [EnumMember(Value = "age_25")]
        Age25,

        [EnumMember(Value = "age_30")]
        Age30,

        [EnumMember(Value = "age_35")]
        Age35,

        [EnumMember(Value = "age_40")]
        Age40,

        [EnumMember(Value = "age_45")]
        Age45,

        [EnumMember(Value = "age_50")]
        Age50
    }
}
