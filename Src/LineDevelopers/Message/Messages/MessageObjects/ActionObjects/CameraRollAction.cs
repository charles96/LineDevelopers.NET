using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(CameraRollAction), "cameraRoll")]
    public class CameraRollAction : IAction
    {
        public CameraRollAction() { }

        [SetsRequiredMembers]
        public CameraRollAction(string label) 
        { 
            this.Label = label;
        }

        /// <summary>
        /// Label for the action
        /// Max character limit: 20
        /// </summary>
        [JsonPropertyName("label")]
        public required string Label { get; set; }
    }
}
