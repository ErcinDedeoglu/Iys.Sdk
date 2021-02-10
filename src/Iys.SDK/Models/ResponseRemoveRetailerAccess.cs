using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class ResponseRemoveRetailerAccess
    {
        [JsonProperty("success")] public bool Success { get; set; }

        [JsonProperty("errors")] public List<IysErrorFull> Errors { get; set; }
    }
}