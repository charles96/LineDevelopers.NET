using System.Runtime.Serialization;

namespace Line.Login
{
    public enum AmrType
    {
        [EnumMember(Value = "pwd")]
        Pwd,

        [EnumMember(Value = "lineautologin")]
        LineAutoLogin,

        [EnumMember(Value = "lineqr")]
        LineQr,

        [EnumMember(Value = "linesso")]
        LineSso
    }
}
