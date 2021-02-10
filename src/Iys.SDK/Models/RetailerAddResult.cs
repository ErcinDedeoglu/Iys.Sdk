using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RetailerAddResult
    {
        [JsonProperty("retailerCode")] public string RetailerCode { get; set; }

        [JsonProperty("errors")] public List<IysError> Errors { get; set; }
    }
}