using System.Runtime.Serialization;

namespace Line.Message
{
    public enum RichMenuOperationType
    {
        [EnumMember(Value = "link")]
        Link,

        [EnumMember(Value = "unlink")]
        UnLink,

        [EnumMember(Value = "unlinkAll")]
        UnlinkAll
    }
}
