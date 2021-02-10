using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class ResponseConsentChanges
    {
        [JsonProperty("after")] public string After { get; set; }

        [JsonProperty("list")] public List<ConsentChangeItem> List { get; set; }
    }
}