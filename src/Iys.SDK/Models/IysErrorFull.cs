using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class IysErrorFull
    {
        [JsonProperty("index")] public int Index { get; set; }

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("location")] public List<string> Location { get; set; }

        [JsonProperty("value")] public string Value { get; set; }

        [JsonProperty("message")] public string Message { get; set; }
    }
}