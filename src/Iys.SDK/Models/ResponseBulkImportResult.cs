using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class ResponseBulkImportResult
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("subRequestId")] public string SubRequestId { get; set; }

        [JsonProperty("index")] public string Index { get; set; }

        [JsonProperty("transactionId")] public string TransactionId { get; set; }

        [JsonProperty("requestId")] public string RequestId { get; set; }

        [JsonProperty("creationDate")] public string CreationDate { get; set; }

        [JsonProperty("error")] public IysError Error { get; set; }
    }
}