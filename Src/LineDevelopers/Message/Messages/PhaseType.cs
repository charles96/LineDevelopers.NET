using System.Runtime.Serialization;

namespace Line.Message
{
    public enum PhaseType
    {
        [EnumMember(Value = "waiting")]
        Waiting,

        [EnumMember(Value = "sending")]
        Sending,

        [EnumMember(Value = "succeeded")]
        Succeeded,

        [EnumMember(Value = "failed")]
        Failed
    }
}