using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class IysError
    {
        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("message")] public string Message { get; set; }
    }
}