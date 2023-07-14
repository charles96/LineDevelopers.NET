using System.Runtime.Serialization;

namespace Line.Message
{
    public enum InputOptions
    {
        [EnumMember(Value = "closeRichMenu")]
        CloseRichMenu,

        [EnumMember(Value = "openRichMenu")]
        OpenRichMenu,

        [EnumMember(Value = "openKeyboard")]
        OpenKeyboard,

        [EnumMember(Value = "openVoice")]
        OpenVoice
    }
}
