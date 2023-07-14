using System.Runtime.Serialization;

namespace Line.Message
{
    public enum WeightType
    {
        [EnumMember(Value = "regular")]
        Regular,

        [EnumMember(Value = "bold")]
        Bold
    }
}
