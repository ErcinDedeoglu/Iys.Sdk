using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RequestConsent
    {
        [JsonProperty("consentDate")]
        public string ConsentDate { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [JsonProperty("recipientType")]
        public string RecipientType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("retailerCode")]
        public int? RetailerCode { get; set; }

        [JsonProperty("retailerAccess")]
        public List<int> RetailerAccess { get; set; } = new List<int>();

        [JsonIgnore]
        public int UserCredentialId { get; set; }
    }
}