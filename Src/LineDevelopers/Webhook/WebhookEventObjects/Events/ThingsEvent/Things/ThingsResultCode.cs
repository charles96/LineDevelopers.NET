using System.Runtime.Serialization;

namespace Line.Webhook
{
    public enum ThingsResultCode
    {
        [EnumMember(Value = "success")]
        Success,

        [EnumMember(Value = "gatt_error")]
        GattError,

        [EnumMember(Value = "runtime_error")]
        RuntimeError,
    }
}
