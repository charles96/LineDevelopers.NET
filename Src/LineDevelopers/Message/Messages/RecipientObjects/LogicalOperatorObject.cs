using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(LogicalOperatorObject), "operator")]
    public class LogicalOperatorObject : IRecipientObject
    {
        public LogicalOperatorObject() { }

        public LogicalOperatorObject(IList<IRecipientObject>? and = null,
                                     IList<IRecipientObject>? or = null,
                                     IRecipientObject? not = null)
        {
            And = and;
            Or = or;
            Not = not;
        }

        [JsonPropertyName("and")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<IRecipientObject>? And { get; set; }

        [JsonPropertyName("or")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<IRecipientObject>? Or { get; set; }

        [JsonPropertyName("not")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IRecipientObject? Not { get; set; }
    }
}
