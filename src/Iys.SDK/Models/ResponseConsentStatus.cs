using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class ResponseConsentStatus
    {
        [JsonProperty("consentDate")] public string ConsentDate { get; set; }

        [JsonProperty("source")] public string Source { get; set; }

        [JsonProperty("recipient")] public string Recipient { get; set; }

        [JsonProperty("recipientType")] public string RecipientType { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("creationDate")] public string CreationDate { get; set; }

        [JsonProperty("retailerAccessCount")] public int RetailerAccessCount { get; set; }

        [JsonProperty("errors")] public List<IysErrorFull> Errors { get; set; }
    }
}