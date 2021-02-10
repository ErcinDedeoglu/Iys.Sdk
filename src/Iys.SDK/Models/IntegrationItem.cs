using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class IntegrationItem
    {
        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("iysCode")] public string IysCode { get; set; }

        [JsonProperty("brands")] public List<IntegrationBrand> Brands { get; set; }
    }
}