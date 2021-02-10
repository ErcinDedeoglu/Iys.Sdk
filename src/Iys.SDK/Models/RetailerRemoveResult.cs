using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RetailerRemoveResult
    {
        [JsonProperty("success")] public bool Success { get; set; }

        [JsonProperty("errors")] public List<IysError> Errors { get; set; }
    }
}