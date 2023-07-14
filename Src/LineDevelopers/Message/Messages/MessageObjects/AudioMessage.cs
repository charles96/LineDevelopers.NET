using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(AudioMessage), "audio")]
    public class AudioMessage : IMessage
    {
        public AudioMessage() { }

        [SetsRequiredMembers]
        public AudioMessage(string originalContentUrl,
                            int duration,
                            QuickReply? quickReply = null)
        { 
            this.OriginalContentUrl = originalContentUrl;
            this.Duration = duration;
            this.QuickReply = quickReply;
        }

        [JsonPropertyName("quickReply")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QuickReply? QuickReply { get; set; }

        /// <summary>
        /// URL of audio file (Max character limit: 2000)
        /// HTTPS over TLS 1.2 or later
        /// m4a
        /// Max file size: 200 MB
        /// Only M4A files are supported on the Messaging API. 
        /// If a service only supports MP3 files, you can use a service like FFmpeg to convert the files to M4A.
        /// </summary>
        [JsonPropertyName("originalContentUrl")]
        public required string OriginalContentUrl { get; set; }

        /// <summary>
        /// Length of audio file (milliseconds)
        /// </summary>
        [JsonPropertyName("duration")]
        public required int Duration { get; set; }
    }
}
