using System.Text.Json.Serialization;

namespace Line.Message
{
    public class SubscriptionPeriodItem
    {
        [JsonPropertyName("subscriptionPeriod")]
        public string SubscriptionPeriod { get; set; }

        [JsonPropertyName("percentage")]
        public decimal Percentage { get; set; }
    }
}