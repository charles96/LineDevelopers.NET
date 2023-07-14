using System.Text.Json.Serialization;

namespace Line.Message
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(PostBackAction), "postback")]
    [JsonDerivedType(typeof(MessageAction), "message")]
    [JsonDerivedType(typeof(UriAction),"uri")]
    [JsonDerivedType(typeof(DateTimePickerAction), "datetimepicker")]
    [JsonDerivedType(typeof(CameraAction), "camera")]
    [JsonDerivedType(typeof(CameraRollAction), "cameraRoll")]
    [JsonDerivedType(typeof(LocationAction),"location")]
    [JsonDerivedType(typeof(RichMenuSwitchAction), "richmenuswitch")]
    public interface IAction
    {
        public string Label { get; set; }
    }
}
