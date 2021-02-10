using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class Integration
    {
        [JsonProperty("pagination")] public IntegrationPagination Pagination { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("list")] public List<IntegrationItem> List { get; set; }
    }
}