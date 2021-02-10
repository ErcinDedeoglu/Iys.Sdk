using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RequestConsentStatus
    {
        [JsonProperty("recipient")] public string Recipient { get; set; }

        [JsonProperty("recipientType")] public string RecipientType { get; set; }

        [JsonProperty("type")] public string Type { get; set; }
    }
}