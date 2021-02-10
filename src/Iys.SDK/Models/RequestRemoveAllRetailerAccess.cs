using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RequestRemoveAllRetailerAccess
    {
        [JsonProperty("recipientType")] public string RecipientType { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("recipients")] public List<string> Recipients { get; set; }
    }
}