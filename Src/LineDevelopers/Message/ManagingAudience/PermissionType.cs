using System.Runtime.Serialization;

namespace Line.Message
{
    public enum PermissionType
    {
        [EnumMember(Value = "READ")]
        Read,

        [EnumMember(Value = "READ_WRITE")]
        ReadWrite
    }
}
