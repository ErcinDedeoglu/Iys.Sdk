using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RetailerItem
    {
        [JsonProperty("canBeDeleted")] public string CanBeDeleted { get; set; }

        [JsonProperty("tckn")] public long Tckn { get; set; }

        [JsonProperty("mersis")] public string Mersis { get; set; }

        [JsonProperty("mobile")] public string Mobile { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("alias")] public string Alias { get; set; }

        [JsonProperty("retailerCode")] public int RetailerCode { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("city")] public RetailerAddr City { get; set; }

        [JsonProperty("town")] public RetailerAddr Town { get; set; }

        [JsonProperty("retailerAccessCount")] public int RetailerAccessCount { get; set; }

        [JsonProperty("errors")] public List<IysError> Errors { get; set; }
    }
}