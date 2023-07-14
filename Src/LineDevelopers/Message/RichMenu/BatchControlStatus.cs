using System.Runtime.Serialization;

namespace Line.Message
{
    public enum BatchControlStatus
    {
        [EnumMember(Value = "ongoing")]
        Ongoing,

        [EnumMember(Value = "succeeded")]
        Succeeded,

        [EnumMember(Value = "failed")]
        Failed
    }
}
