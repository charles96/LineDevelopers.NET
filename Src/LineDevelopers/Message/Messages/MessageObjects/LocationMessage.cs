using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(LocationMessage), "location")]
    public class LocationMessage : IMessage
    {
        public LocationMessage() { }

        [SetsRequiredMembers]
        public LocationMessage(string title,
                               string address,
                               decimal latitude,
                               decimal longitude,
                               QuickReply? quickReply = null) 
        { 
            this.Title = title;
            this.Address = address;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.QuickReply = quickReply;
        }

        [JsonPropertyName("quickReply")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QuickReply? QuickReply { get; set; }

        /// <summary>
        /// Title
        /// Max character limit: 100
        /// </summary>
        [JsonPropertyName("title")]
        public required string Title { get; set; }

        /// <summary>
        /// Address
        /// Max character limit: 100
        /// </summary>
        [JsonPropertyName("address")]
        public required string Address { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        [JsonPropertyName("latitude")]
        public required decimal Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [JsonPropertyName("longitude")]
        public required decimal Longitude { get; set; }
    }
}
