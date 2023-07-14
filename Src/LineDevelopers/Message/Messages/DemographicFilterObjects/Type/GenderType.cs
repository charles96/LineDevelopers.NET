using System.Runtime.Serialization;

namespace Line.Message
{
    public enum GenderType
    {
        [EnumMember(Value = "male")]
        Male,

        [EnumMember(Value = "female")]
        Female
    }
}
