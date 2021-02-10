using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RetailerConsentModel
    {
        [JsonProperty("pagination")] public RetailerPagination Pagination { get; set; }

        [JsonProperty("list")] public List<RetailerConsentItem> List { get; set; }

        [JsonProperty("errors")] public List<IysError> Errors { get; set; }
    }
}