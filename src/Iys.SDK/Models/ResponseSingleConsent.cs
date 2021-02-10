using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class ResponseSingleConsent
    {
        [JsonProperty("transactionId")] public string TransactionId { get; set; }

        [JsonProperty("creationDate")] public string CreationDate { get; set; }

        [JsonProperty("errors")] public List<IysErrorFull> Errors { get; set; }
    }
}