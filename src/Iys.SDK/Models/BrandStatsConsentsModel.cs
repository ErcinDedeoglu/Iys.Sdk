using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class BrandStatsConsentsModel
    {
        [JsonProperty("approval")] public int Approval { get; set; }

        [JsonProperty("rejection")] public int Rejection { get; set; }

        [JsonProperty("total")] public int Total { get; set; }
    }
}