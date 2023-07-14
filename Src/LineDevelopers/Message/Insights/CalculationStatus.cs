using System.Runtime.Serialization;

namespace Line.Message
{
    public enum CalculationStatus
    {
        [EnumMember(Value = "ready")]
        Ready,

        [EnumMember(Value = "unready")]
        UnReady,

        [EnumMember(Value = "out_of_service")]
        OutOfService
    }
}
