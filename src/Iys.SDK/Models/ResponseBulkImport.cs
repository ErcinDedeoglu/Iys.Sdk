using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class ResponseBulkImport
    {
        [JsonProperty("requestId")]
        public Guid RequestId { get; set; }

        [JsonProperty("subRequests")]
        public List<SubRequest> SubRequests { get; set; }

        [JsonProperty("errors")]
        public List<IysErrorFull> Errors { get; set; }
    }
}