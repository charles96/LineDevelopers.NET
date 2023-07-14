using System.Runtime.Serialization;

namespace Line.Liff
{
    public enum ViewType
    {
        [EnumMember(Value = "compact")]
        Compact,

        [EnumMember(Value = "tall")]
        Tall,

        [EnumMember(Value = "full")]
        Full
    }
}
