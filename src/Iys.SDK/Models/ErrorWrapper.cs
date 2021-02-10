using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class ErrorWrapper
    {
        [JsonProperty("errors")] public List<IysError> List { get; set; }
    }
}