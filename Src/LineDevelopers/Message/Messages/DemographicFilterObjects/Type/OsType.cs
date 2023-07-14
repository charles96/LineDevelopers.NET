using System.Runtime.Serialization;

namespace Line.Message
{
    public enum OsType
    {
        [EnumMember(Value = "ios")]
        iOS,

        [EnumMember(Value = "android")]
        Android,
    }
}
