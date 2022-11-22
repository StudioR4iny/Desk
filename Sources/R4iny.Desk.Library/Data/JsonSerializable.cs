using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace R4iny.Desk.Library.Data
{
    public class JsonSerializable
    {
        public JObject ToJson() => JObject.Parse(this.ToString());
        public override string ToString() => this.ToString(false);
        public static implicit operator string(JsonSerializable obj) => obj.ToString(); // obj?.ToString();
        public string ToString(bool isIndented) => JsonConvert.SerializeObject(
            value: this,
            formatting: isIndented ? Formatting.Indented : Formatting.None,
            settings: JsonSerializable.JsonSerializerSetting);

        public static readonly JsonSerializerSettings JsonSerializerSetting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Include,
        };
    }
}
