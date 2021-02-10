using System;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class SubRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("consentDate")]
        public string ConsentDate { get; set; }

        [JsonProperty("recipientType")]
        public string RecipientType { get; set; }

        [JsonProperty("subRequestId")]
        public Guid SubRequestId { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }
    }
}