using System.Runtime.Serialization;

namespace Line.Message
{
    public enum ChatType
    {
        [EnumMember(Value = "chat")]
        Chat,

        [EnumMember(Value = "bot")]
        Bot
    }
}
