using System.Text.Json.Serialization;

namespace Line.Message
{
    public class RichMenuList
    {
        [JsonPropertyName("richmenus")]
        public IList<RichMenuResponseObject> RichMenus { get; set; }
    }
}
