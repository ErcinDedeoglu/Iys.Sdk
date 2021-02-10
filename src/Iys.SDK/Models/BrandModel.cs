using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class BrandModel
    {
        [JsonProperty("brandCode")] public int BrandCode { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("master")] public bool Master { get; set; }

        [JsonProperty("stats")] public BrandStatsModel Stats { get; set; }
    }
}