using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class BrandStatsModel
    {
        [JsonProperty("consents")] public BrandStatsConsentsModel Consents { get; set; }

        [JsonProperty("retailers")] public BrandStatsRetailersModel Retailers { get; set; }
    }
}