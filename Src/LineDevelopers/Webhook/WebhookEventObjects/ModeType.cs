using System.Runtime.Serialization;

namespace Line.Webhook
{
    public enum ModeType
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "standby")]
        Standby
    }
}
