using System.Runtime.Serialization;

namespace Line.Webhook
{
    public enum StickerResourceType
    {
        [EnumMember(Value = "STATIC")]
        Static,

        [EnumMember(Value = "ANIMATION")]
        Animation,

        [EnumMember(Value = "SOUND")]
        Sound,

        [EnumMember(Value = "ANIMATION_SOUND")]
        AnimationSound,

        [EnumMember(Value = "POPUP")]
        PopUp,

        [EnumMember(Value = "POPUP_SOUND")]
        PopUpSound,

        [EnumMember(Value = "CUSTOM")]
        Custom,

        [EnumMember(Value = "MESSAGE")]
        Message,

        [EnumMember(Value = "NAME_TEXT")]
        NameText,

        [EnumMember(Value = "PER_STICKER_TEXT")]
        PerStickerText
    }
}
