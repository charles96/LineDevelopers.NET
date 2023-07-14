using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(GenderDemographicFilterObject), "gender")]
    [JsonDerivedType(typeof(AgeDemographicFilterObject), "age")]
    [JsonDerivedType(typeof(OperationSystemDemographicFilterObject), "appType")]
    [JsonDerivedType(typeof(RegionDemographicFilterObject), "area")]
    [JsonDerivedType(typeof(FriendshipDurationDemographicFilterObject), "subscriptionPeriod")]
    [JsonDerivedType(typeof(LogicalOperationDemographicFilterObject), "operator")]
    public interface IDemographicFilterObjects
    {
    }
}
