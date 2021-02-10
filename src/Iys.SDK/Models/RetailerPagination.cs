using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RetailerPagination
    {
        [JsonProperty("offset")] public int Offset { get; set; }

        [JsonProperty("totalCount")] public int TotalCount { get; set; }

        [JsonProperty("pageSize")] public int PageSize { get; set; }
    }
}