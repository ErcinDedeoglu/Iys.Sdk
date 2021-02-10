using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RequestRetailerAccess
    {
        [JsonProperty("recipient")] public string Recipient { get; set; }

        [JsonProperty("recipientType")] public string RecipientType { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("retailerAccess")] public List<int> RetailerAccess { get; set; }
    }
}