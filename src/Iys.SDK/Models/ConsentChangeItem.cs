using System;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class ConsentChangeItem
    {
        [JsonProperty("consentDate")] public DateTime ConsentDate { get; set; }

        [JsonProperty("creationDate")] public DateTime CreationDate { get; set; }

        [JsonProperty("source")] public string Source { get; set; }

        [JsonProperty("recipient")] public string Recipient { get; set; }

        [JsonProperty("recipientType")] public string RecipientType { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("transactionId")] public string TransactionId { get; set; }
    }
}