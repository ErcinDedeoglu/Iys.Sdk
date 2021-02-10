using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RetailerModel
    {
        [JsonProperty("pagination")] public RetailerPagination Pagination { get; set; }

        [JsonProperty("list")] public List<RetailerItem> List { get; set; }

        [JsonProperty("errors")] public List<IysError> Errors { get; set; }
    }
}