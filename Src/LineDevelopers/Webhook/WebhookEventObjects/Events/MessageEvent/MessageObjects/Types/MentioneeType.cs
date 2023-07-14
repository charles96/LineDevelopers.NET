using System.Runtime.Serialization;

namespace Line.Webhook
{
    public enum MentioneeType
    {
        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "all")]
        All
    }
}
