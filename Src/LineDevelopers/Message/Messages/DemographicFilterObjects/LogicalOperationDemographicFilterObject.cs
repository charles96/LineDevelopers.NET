using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(LogicalOperationDemographicFilterObject), "operator")]
    public class LogicalOperationDemographicFilterObject : IDemographicFilterObjects
    {
        public LogicalOperationDemographicFilterObject() { }

        public LogicalOperationDemographicFilterObject(IList<IDemographicFilterObjects>? and = null,
                                                       IList<IDemographicFilterObjects>? or = null,
                                                       IDemographicFilterObjects? not = null)
        {
            And = and;
            Or = or;
            Not = not;
        }

        [JsonPropertyName("and")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<IDemographicFilterObjects>? And { get; set; }

        [JsonPropertyName("or")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<IDemographicFilterObjects>? Or { get; set; }

        [JsonPropertyName("not")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IDemographicFilterObjects? Not { get; set; }
    }
}
