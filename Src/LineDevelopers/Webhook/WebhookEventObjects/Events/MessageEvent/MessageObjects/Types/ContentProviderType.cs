using System.Runtime.Serialization;

namespace Line.Webhook
{
    public enum ContentProviderType
    {
        [EnumMember(Value = "line")]
        Line,

        [EnumMember(Value = "external")]
        External
    }
}
