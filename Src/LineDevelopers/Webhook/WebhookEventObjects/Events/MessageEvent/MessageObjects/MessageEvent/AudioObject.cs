﻿using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(AudioObject), "audio")]
    public class AudioObject : IMessageObject
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Duration { get; set; }

        [JsonPropertyName("contentProvider")]
        public ContentProvider ContentProvider { get; set; }
    }
}
