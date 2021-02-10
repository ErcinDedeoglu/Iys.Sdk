using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class IntegrationList
    {
        [JsonProperty("list")] public List<IntegrationItem> List { get; set; }
    }
}