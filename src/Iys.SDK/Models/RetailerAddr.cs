using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RetailerAddr
    {
        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }
}