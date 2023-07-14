using System.Runtime.Serialization;

namespace Line.Webhook
{
    public enum RichMenuType
    {
        [EnumMember(Value = "SUCCESS")]
        Success,

        [EnumMember(Value = "RICHMENU_ALIAS_ID_NOTFOUND")]
        RichMenuAliasIdNotFound,

        [EnumMember(Value = "RICHMENU_NOTFOUND")]
        RichMenuNotFound,

        [EnumMember(Value = "FAILED")]
        Failed
    }
}
