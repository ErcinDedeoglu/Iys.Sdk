using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RequestRemoveRetailerAccess
    {
        [JsonProperty("recipientType")] public string RecipientType { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("recipients")] public List<string> Recipients { get; set; }

        [JsonProperty("retailerAccess")] public List<int> Retailers { get; set; }
    }
}