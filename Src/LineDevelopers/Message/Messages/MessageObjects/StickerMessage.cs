using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(StickerMessage), "sticker")]
    public class StickerMessage : IMessage
    {
        public StickerMessage() { }

        [SetsRequiredMembers]
        public StickerMessage(string packageId,
                              string stickerId,
                              QuickReply? quickReply = null) 
        { 
            this.PackageId = packageId;
            this.StickerId = stickerId;
            this.QuickReply = quickReply;
        }

        [JsonPropertyName("quickReply")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QuickReply? QuickReply { get; set; }

        /// <summary>
        /// Package ID for a set of stickers. For information on package IDs, see the List of available stickers.
        /// </summary>
        [JsonPropertyName("packageId")]
        public required string PackageId { get; set; }

        /// <summary>
        /// Sticker ID. For a list of sticker IDs for stickers that can be sent with the Messaging API, see the List of available stickers.
        /// </summary>
        [JsonPropertyName("stickerId")]
        public required string StickerId { get; set; }
    }
}
