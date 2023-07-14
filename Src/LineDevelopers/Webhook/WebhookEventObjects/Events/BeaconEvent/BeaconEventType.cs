using System.Runtime.Serialization;

namespace Line.Webhook
{
    public enum BeaconEventType
    {
        [EnumMember(Value = "enter")]
        Enter,

        [EnumMember(Value = "banner")]
        Banner,

        [EnumMember(Value = "stay")]
        Stay
    }
}
