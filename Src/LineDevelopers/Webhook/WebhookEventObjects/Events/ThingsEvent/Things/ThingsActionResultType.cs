using System.Runtime.Serialization;

namespace Line.Webhook
{
    public enum ThingsActionResultType
    {
        [EnumMember(Value = "void")]
        Void,

        [EnumMember(Value = "binary")]
        Binary
    }
}
